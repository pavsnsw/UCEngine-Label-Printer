using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCEngine_Label_Printer.FileManager
{
    class FileManager
    {
        private static readonly Lazy<FileManager> lazy =
            new Lazy<FileManager>(() => new FileManager());

        /// <summary>
        /// Retrieves instance of FileManager object
        /// </summary>
        public static FileManager Instance { get { return lazy.Value; } }

        public string Root { get; private set; }
        public string TemplateFolder
        {
            get { return Path.Combine(Root, "templates"); }
        }

        private FileManager()
        {
            GetRoot();
        }

        private void GetRoot()
        {
            Root  = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
        }

        public string TemplateFile(string name)
        {
            return Path.Combine(TemplateFolder, name);
        }
    }
}
