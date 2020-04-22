using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using infosecSoft.infosecPDF.Helper;
using infosecSoft.infosecPDF.PrintFile;

namespace infosecSoft.infosecPDF.COM
{
    internal class PrintFileHelperCom : PrintFileHelperBase
    {
        public bool AllowDefaultPrinterSwitch { get; set; }

        protected override void DirectoriesNotSupportedHint()
        {
            throw new COMException("Directories cannot be printed!");
        }

        protected override void UnprintableFilesHint(IList<PrintCommand> unprintable)
        {
            var unprintableFilesNames = new StringBuilder("The following file cannot be printed: \n");

            foreach (var unprintableFile in unprintable) unprintableFilesNames.AppendLine(unprintableFile.Filename);

            throw new COMException(unprintableFilesNames.ToString());
        }

        protected override bool QuerySwitchDefaultPrinter()
        {
            //Depending on what the COM user chose to do, we set the
            //default printer or not
            return AllowDefaultPrinterSwitch;
        }
    }
}