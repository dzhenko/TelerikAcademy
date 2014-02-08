namespace GsmClass
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GSM
    {

        //iphone4S private field
        private static readonly GSM iphone4S = new GSM("Iphone 4S", "Apple", 1300.00m, "Globul",
                                                    new Battery("Apple", 8, 200, Battery.Type.LiPo),
                                                    new Display(960, 640, 16000000));

        //private constant callPrice
        private const decimal callPricePerSecond = 0.37m;

        //private constants
        //instead of null values..
        private const decimal defaultPrice = 1800;
        private const string defaultOwner = "JCorp";

        //private fields
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> CallHistory;
        
        //default constructor with only model and manufacturer (can not be empty)
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, defaultPrice, defaultOwner, new Battery(), new Display()) { }

        //constructor with full arguments
        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;

            this.CallHistory = new List<Call>();
        }

        //property model
        public string Model
        {
            get { return model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Model can NOT be null or empty!");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Manufacturer can NOT be null or empty!");
                }
                this.manufacturer = value;
            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ApplicationException("Price can NOT be a negative number!");
                }
                this.price = value;
            }
        }

        public string Owner
        {
            get { return owner; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Owner can NOT be null or empty!");
                }
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get { return battery; }
            set { this.battery = value; } //data validity checked in battery class
        }

        public Display Display
        {
            get { return display; }
            set { this.display = value; } //data validity checked in display class
        }

        public static GSM IPhone4S
        {
            get
            {
                return iphone4S;
            }
        }

        public override string ToString()
        {
            StringBuilder stringCreator = new StringBuilder();
            stringCreator.Append("GSM Specifications:");
            stringCreator.Append(" ");
            stringCreator.AppendLine(new string('-', 90));
            stringCreator.AppendFormat("GSM Model - {0}", this.model);
            stringCreator.AppendLine();
            stringCreator.AppendFormat("GSM Manufacturer - {0}", this.manufacturer);
            stringCreator.AppendLine();
            stringCreator.AppendFormat("GSM Price - {0}", this.price);
            stringCreator.AppendLine();
            stringCreator.AppendFormat("GSM Owner - {0}", this.owner);
            stringCreator.AppendLine();
            stringCreator.AppendFormat("GSM Battery Specifications : Model - {1} , Type - {0} , talk time - {2} , idle time - {3}"
                          , this.Battery.BatteryType, this.Battery.Model, this.Battery.HoursTalk, this.Battery.HoursIdle);
            stringCreator.AppendLine();
            stringCreator.AppendFormat("GSM Display Specifications : Height - {0} , Width - {1} , Number of Colors - {2}",
                            this.Display.Height, this.Display.Width, this.Display.NumberOfColors);
            stringCreator.AppendLine();
            stringCreator.AppendLine(new string('-', 110));

            return stringCreator.ToString();
        }

        //add call method (takes number as a string and duaration - dateTime is always NOW)
        public void AddCall(string currPhoneNumber, ulong currDuaration)
        {
            this.CallHistory.Add(new Call(currPhoneNumber, currDuaration));
        }

        //remove call - takes a position from the ShowCallHistoryMethod - starts count from 1 not 0 for more user friendly interface
        public void DeleteCall(int position)
        {
            if ((this.CallHistory.Count <= position - 1) || (position - 1 < 0))
            {
                throw new ApplicationException("Such call history log does not exist!");
            }
            this.CallHistory.RemoveAt(position - 1);
        }

        //adds an index so users can choose which call to delete
        public void ShowCallHistory()
        {
            Console.WriteLine("Current call history:");
            int indexer = 1;
            foreach (var call in this.CallHistory)
            {
                Console.Write(indexer++);
                Console.Write(" ---> ");
                Console.WriteLine(call.ToString());
            }
        }

        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        public decimal TotalCallPrice()
        {
            ulong allDuaration = 0;
            foreach (var call in this.CallHistory)
            {
                allDuaration += call.Duaration;
            }

            return allDuaration * callPricePerSecond;
        }
    }
}