using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCEngine_Label_Printer.LabelPrinter
{
    public class UCEngineLabelWizard
    {
        private string templatePath;

        private string[] labelHeaders =
            {"deviceType", "date", "windowsVersion", "mtrVersion", "ccsVersion", "macAddress", "slotNo"};

        private BrotherLabel label;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="templatePath">Path to template</param>
        public UCEngineLabelWizard(string templatePath)
        {
            this.templatePath = templatePath;
            label = new BrotherLabel(templatePath);
            label.SetPrinter(0);
        }

        /// <summary>
        /// Print label
        /// </summary>
        /// <param name="deviceType">Device type/model</param>
        /// <param name="date">Date of configuration</param>
        /// <param name="windowsVersion">Windows Version</param>
        /// <param name="mtrVersion">Microsoft Teams Room version</param>
        /// <param name="ccsVersion">CCS version</param>
        /// <param name="macAddress">Device MAC Address</param>
        /// <param name="slotNo">Rack slot number</param>
        public void Print(string deviceType, string date, string windowsVersion, string mtrVersion,
            string ccsVersion, string macAddress, string slotNo)
        {
            label.SetTemplateObject(labelHeaders[0], deviceType);
            label.SetTemplateObject(labelHeaders[1], date);
            label.SetTemplateObject(labelHeaders[2], windowsVersion);
            label.SetTemplateObject(labelHeaders[3], mtrVersion);
            label.SetTemplateObject(labelHeaders[4], ccsVersion);
            label.SetTemplateObject(labelHeaders[5], macAddress);
            label.SetTemplateObject(labelHeaders[6], slotNo);

            label.Print();
        }
    }
}
