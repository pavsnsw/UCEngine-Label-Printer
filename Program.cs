using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCEngine_Label_Printer.LabelPrinter;
using UCEngine_Label_Printer.FileManager;

namespace UCEngine_Label_Printer
{
    class Program
    {
        static string deviceType, date, windowsVer, mtrVer, ccsVer, macAddress, slotNo;
        static string templatePath;
        static string templateName = "PreConfig_UC.lbx";

        static void Main(string[] args)
        {
            if (VerifyArgs(args))
            {
                templatePath = FileManager.FileManager.Instance.TemplateFile(templateName);
                //Console.WriteLine(templatePath);

                UCEngineLabelWizard wizard = new UCEngineLabelWizard(templatePath);

                wizard.Print(deviceType, date, windowsVer, mtrVer, ccsVer, macAddress, slotNo);
            }
            else
            {
                Console.WriteLine("Error - invalid arguments, please check");
            }
        }

        static bool VerifyArgs(string[] args)
        {
            if(args.Length == 7)
            {
                deviceType = args[0];
                date = args[1];
                windowsVer = args[2];
                mtrVer = args[3];
                ccsVer = args[4];
                macAddress = args[5];
                slotNo = args[6];

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
