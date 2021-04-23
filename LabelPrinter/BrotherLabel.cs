using System;
using System.Collections.Generic;
using bpac;

namespace UCEngine_Label_Printer.LabelPrinter
{
    public class BrotherLabel
    {
        private Document doc;
        private string templatePath;
        private Dictionary<string, string> commands = new Dictionary<string, string>();
        private string selectedPrinter;

        public List<string> PrinterNames { get; private set; } = new List<string>();

        public BrotherLabel(string templatePath)
        {
            doc = new Document();
            this.templatePath = templatePath;

            GetPrinterNames();
        }

        public void SetPrinter(string printer)
        {
            if (PrinterNames.Contains(printer))
            {
                selectedPrinter = printer;
            }
            else
            {
                throw new ArgumentException("Printer does not exist");
            }
        }

        public void SetPrinter(int index)
        {
            selectedPrinter = PrinterNames[index];
        }

        public void ClearQueue()
        {
            commands.Clear();
        }

        public void SetTemplateObject(string objectName, string value)
        {
            commands[objectName] = value;
        }

        public void Print()
        {
            doc.Open(templatePath);
            doc.SetPrinter(selectedPrinter, true);

            foreach (var option in commands)
            {
                try
                {
                    doc.GetObject(option.Key).Text = option.Value;
                }
                catch (NullReferenceException e)
                {
                    throw new NullReferenceException($"Object {option.Key} does not exist.");
                }
            }

            doc.StartPrint("", PrintOptionConstants.bpoDefault);
            doc.PrintOut(1, PrintOptionConstants.bpoDefault);
            doc.EndPrint();
            doc.Close();

            ClearQueue();
        }

        private void GetPrinterNames()
        {
            object[] printers = (object[])doc.Printer.GetInstalledPrinters();

            foreach (var printer in printers)
            {
                PrinterNames.Add(printer.ToString());
            }
        }
    }
}
