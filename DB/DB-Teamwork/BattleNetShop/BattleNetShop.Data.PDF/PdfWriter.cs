namespace BattleNetShop.Data.Pdf
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    using MigraDoc.DocumentObjectModel;
    using MigraDoc.DocumentObjectModel.Tables;
    using MigraDoc.Rendering;
    using PdfSharp.Pdf;

    using BattleNetShop.ReportsModel;

    public class PdfWriter
    {
        public void GenerateReport(ProductsReport report, string fileName)
        {
            this.GenerateReport(report, PdfSettings.Default.ReportsFolder, fileName);
        }

        public void GenerateReport(ProductsReport report, string destinationFolder, string fileName)
        {
            var document = this.CreateDocument(fileName);

            this.DefineStyles(document);

            var table = this.TableHeader(document, fileName);

            this.Columns(table);

            var useName = true;
            var useDate = true;

            if (fileName.Contains("Realm"))
            {
                useName = true;
            }

            if (fileName.Contains("Date"))
            {
                useName = false;
            }

            if (fileName.Contains("Single"))
            {
                useName = false;
                useDate = false;
            }

            this.HeaderRows(table, useName, useDate);

            this.FillData(report, table, useName, useDate);

            this.RenderDocument(document, destinationFolder, fileName);
        }

        private Document CreateDocument(string filename)
        {
            var theDocument = new Document();

            theDocument.Info.Title = filename;
            theDocument.Info.Author = "Telerik Sharpshooter DB Team";
            theDocument.Info.Subject = "This is the description of the document";
            theDocument.Info.Keywords = "Blizzard, BattleNet, Diablo, Warcraft, Sales, Items";

            return theDocument;
        }

        private void DefineStyles(Document document)
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];

            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Arial";

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 9;

            // Create a new style called Reference based on style Normal
            style = document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        private Table TableHeader(Document document, string fileName)
        {
            // Each MigraDoc document needs at least one section.
            Section section = document.AddSection();

            // Create Header
            Paragraph paragraph = section.Headers.Primary.AddParagraph();
            paragraph.AddText(fileName);
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            // Create the item table
            var mainTable = section.AddTable();
            mainTable.Style = "Table";
            mainTable.Borders.Color = Colors.Azure;
            mainTable.Borders.Width = 0.25;
            mainTable.Borders.Left.Width = 0.5;
            mainTable.Borders.Right.Width = 0.5;
            mainTable.Rows.LeftIndent = 0;

            return mainTable;
        }

        private void Columns(Table table)
        {
            // Before you can add a row, you must define the columns
            var column = table.AddColumn("5.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            for (int i = 0; i < 4; i++)
            {
                table.AddColumn("2cm").Format.Alignment = ParagraphAlignment.Right;
            }
        }

        private void HeaderRows(Table table, bool useName, bool useDate)
        {
            var row = table.AddRow();
            row.Height = "1cm";
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = Colors.LightGray;

            row.Cells[0].AddParagraph(useName ? "Product" : useDate ? "Date" : "Location");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[1].AddParagraph("Vendor");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[2].AddParagraph("Unit Price");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[2].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[3].AddParagraph("Quantity");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[3].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[4].AddParagraph("Sum");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[4].VerticalAlignment = VerticalAlignment.Center;

            table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);
        }

        private void FillData(ProductsReport productReport, Table table, bool useName, bool useDate)
        {
            var productReportEntries = productReport.Products;

            foreach (var reportRow in productReportEntries)
            {
                Row row = table.AddRow();
                row.Height = "1cm";
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = Colors.YellowGreen;

                row.Cells[0].AddParagraph(useName ? reportRow.Name : useDate ? productReport.Date.ToString("dd-MMM-yyyy") : reportRow.Location);
                row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].VerticalAlignment = VerticalAlignment.Center;

                row.Cells[1].AddParagraph(reportRow.Vendor);
                row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[1].VerticalAlignment = VerticalAlignment.Center;

                row.Cells[2].AddParagraph(reportRow.Price.ToString());
                row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[2].VerticalAlignment = VerticalAlignment.Center;

                row.Cells[3].AddParagraph(reportRow.Quantity.ToString());
                row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[3].VerticalAlignment = VerticalAlignment.Center;

                row.Cells[4].AddParagraph(reportRow.Total.ToString());
                row.Cells[4].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[4].VerticalAlignment = VerticalAlignment.Center;
            }

            var totalSum = productReportEntries.Sum(x => x.Total);
            Row totalSumRow = table.AddRow();
            totalSumRow.Height = "1cm";
            totalSumRow.HeadingFormat = true;
            totalSumRow.Format.Alignment = ParagraphAlignment.Center;
            totalSumRow.Format.Font.Bold = true;
            totalSumRow.Shading.Color = Colors.LightGray;
            totalSumRow.Cells[0].AddParagraph("Total: " + totalSum.ToString());
            totalSumRow.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            totalSumRow.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            totalSumRow.Cells[0].MergeRight = 4;
        }

        private void RenderDocument(Document document, string destinationFolder, string fileName)
        {
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            // Render The Document
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
            pdfRenderer.Document = document;

            pdfRenderer.RenderDocument();

            pdfRenderer.PdfDocument.Save(destinationFolder + fileName + ".pdf");

            // TODO: Needed ?
            //Process.Start(fileName);
        }
    }
}
