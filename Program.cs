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
        static int noArgs = 8;

        static void Main(string[] args)
        {
            try
            {
                if (VerifyArgs(args))
                {
                    Console.WriteLine($"Printing from template {templatePath}");

                    UCEngineLabelWizard wizard = new UCEngineLabelWizard(templatePath);

                    wizard.Print(deviceType, date, windowsVer, mtrVer, ccsVer, macAddress, slotNo);
                }
                else
                {
                    Console.WriteLine("Something went wrong - check your arguments");
                    //Console.Error("Something went wrong - please check your arguments again.");
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            
        }

        static bool VerifyArgs(string[] args)
        {
            if(args.Length == noArgs)
            {
                templatePath = args[0];
                deviceType = args[1];
                date = args[2];
                windowsVer = args[3];
                mtrVer = args[4];
                ccsVer = args[5];
                macAddress = args[6];
                slotNo = args[7];

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
