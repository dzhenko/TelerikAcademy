namespace Cars.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using Cars.Client.Logger;
    using Cars.Data;
    using Cars.Models;

    public class XmlQueriesProcessor
    {
        private CarsDbContext context;
        private ILogger logger;

        public XmlQueriesProcessor(CarsDbContext contextToUse, ILogger loggerToUse)
        {
            this.context = contextToUse;
            this.logger = loggerToUse;
        }

        public void ProcessQueries(string queriesInputXmlPath, string outputDirectoryPath)
        {
            this.logger.Log(string.Format("Processing queries from file {0} \n",
               queriesInputXmlPath.Substring(queriesInputXmlPath.LastIndexOf('\\') + 1)));

            var xQueryDocument = XDocument.Load(queriesInputXmlPath).Element("Queries");

            var xQueries = xQueryDocument.Elements("Query");

            foreach (var xQuery in xQueries)
            {
                this.logger.Log(".");

                var carsQuery = this.context.Cars.AsQueryable();

                AttachWhereClauseOnQuery(xQuery, ref carsQuery);

                AttachOrderByClauseOnQuery(xQuery, ref carsQuery);

                var resultXml = new XElement("Cars");

                AttachNamespacesToResult(xQueryDocument, resultXml);

                AttachResults(carsQuery, resultXml);

                var outputFileName = xQuery.Attribute("OutputFileName").Value;
                resultXml.Save(outputDirectoryPath + outputFileName);
            }
            
            this.logger.Log("\nDone\n");
        }

        private void AttachResults(IQueryable<Car> carsQuery, XElement resultXml)
        {
            var mathchedCars = carsQuery.Select(c => new 
            {
                Manufacturer = c.Manufacturer.Name,
                Model = c.Model,
                Year = c.Year,
                Price = c.Price,
                DealerName = c.Dealer.Name,
                TransmisionType = c.TransmissionType,
                Cities = c.Dealer.Cities.Select(city => city.Name)
            });

            foreach (var car in mathchedCars)
            {
                var carResult = new XElement("Car");

                carResult.Add(new XAttribute("Manufacturer", car.Manufacturer));
                carResult.Add(new XAttribute("Model", car.Model));
                carResult.Add(new XAttribute("Year", car.Year));
                carResult.Add(new XAttribute("Price", car.Price));

                carResult.Add(new XElement("TransmissionType", car.TransmisionType.ToString()));

                var dealerTag = new XElement("Dealer");
                dealerTag.Add(new XAttribute("Name", car.DealerName));

                var citiesTag = new XElement("Cities");

                foreach (var city in car.Cities)
                {
                    citiesTag.Add(new XElement("City", city));
                }

                dealerTag.Add(citiesTag);

                carResult.Add(dealerTag);

                resultXml.Add(carResult);
            }
        }

        private void AttachOrderByClauseOnQuery(XElement xQuery, ref IQueryable<Car> query)
        {
            var orderClause = xQuery.Element("OrderBy");

            if (orderClause == null)
            {
                return;
            }

            switch (orderClause.Value)
            {
                case "Id": query = query.OrderBy(c => c.Id); break;
                case "Year": query = query.OrderBy(c => c.Year); break;
                case "Model": query = query.OrderBy(c => c.Model); break;
                case "Price": query = query.OrderBy(c => c.Price); break;
                case "Manufacturer": query = query.OrderBy(c => c.Manufacturer.Name); break;
                case "Dealer": query = query.OrderBy(c => c.Dealer.Name); break;
                default: break;
            }
        }

        private void AttachWhereClauseOnQuery(XElement xQuery, ref IQueryable<Car> query)
        {
            var whereClauses = xQuery.Element("WhereClauses");

            if (whereClauses == null)
            {
                return;
            }

            foreach (var whereClause in whereClauses.Elements())
            {
                var propertyName = whereClause.Attribute("PropertyName").Value;
                var type = whereClause.Attribute("Type").Value;

                var valueAsString = whereClause.Value;
                int valueAsInt = 0;
                decimal valueAsDecimal = 0;

                if (propertyName == "Id" || propertyName == "Year")
                {
                    valueAsInt = int.Parse(valueAsString);
                }
                if (propertyName == "Price")
                {
                    valueAsDecimal = decimal.Parse(valueAsString);
                }

                switch (propertyName)
                {
                    case "Id":
                        if (type == "Equals")
                        {
                            query = query.Where(c => c.Id == valueAsInt);
                        }
                        else if (type == "GreaterThan")
                        {
                            query = query.Where(c => c.Id > valueAsInt);
                        }
                        else if (type == "LessThan")
                        {
                            query = query.Where(c => c.Id < valueAsInt);
                        }
                        break;
                    case "Year":
                        if (type == "Equals")
                        {
                            query = query.Where(c => c.Year == valueAsInt);
                        }
                        else if (type == "GreaterThan")
                        {
                            query = query.Where(c => c.Year > valueAsInt);
                        }
                        else if (type == "LessThan")
                        {
                            query = query.Where(c => c.Year < valueAsInt);
                        }
                        break;
                    case "Price":
                        if (type == "Equals")
                        {
                            query = query.Where(c => c.Price == valueAsDecimal);
                        }
                        else if (type == "GreaterThan")
                        {
                            query = query.Where(c => c.Price > valueAsDecimal);
                        }
                        else if (type == "LessThan")
                        {
                            query = query.Where(c => c.Price < valueAsDecimal);
                        }
                        break;
                    case "Model":
                        if (type == "Equals")
                        {
                            query = query.Where(c => c.Model == valueAsString);
                        }
                        else if (type == "Contains")
                        {
                            query = query.Where(c => c.Model.Contains(valueAsString));
                        }
                        break;
                    case "Manufacturer":
                        if (type == "Equals")
                        {
                            query = query.Where(c => c.Manufacturer.Name == valueAsString);
                        }
                        else if (type == "Contains")
                        {
                            query = query.Where(c => c.Manufacturer.Name.Contains(valueAsString));
                        }
                        break;
                    case "Dealer":
                        if (type == "Equals")
                        {
                            query = query.Where(c => c.Dealer.Name == valueAsString);
                        }
                        else if (type == "Contains")
                        {
                            query = query.Where(c => c.Dealer.Name.Contains(valueAsString));
                        }
                        break;
                    case "City":
                        if (type == "Equals")
                        {
                            query = query.Where(c => c.Dealer.Cities.Any(city => city.Name == valueAsString));
                        }
                        break;
                    default: break;
                }
            }
        }

        private void AttachNamespacesToResult(XElement xQueryDocument, XElement resultXml)
        {
            var documentAttributes = xQueryDocument.Attributes();

            foreach (var attribute in documentAttributes)
            {
                var nsValue = attribute.Value;

                if (attribute.IsNamespaceDeclaration)
                {
                    if (nsValue.EndsWith("XMLSchema-instance"))
                    {
                        resultXml.Add(new XAttribute(XNamespace.Xmlns + "xsi", nsValue));
                    }
                    else if (nsValue.EndsWith("XMLSchema"))
                    {
                        resultXml.Add(new XAttribute(XNamespace.Xmlns + "xsd", nsValue));
                    }
                }
            }
        }
    }
}
