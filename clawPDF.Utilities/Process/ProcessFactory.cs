using System.Diagnostics;

namespace infosecSoft.infosecPDF.Utilities.Process
{
    public class ProcessWrapperFactory
    {
        public virtual ProcessWrapper BuildProcessWrapper(ProcessStartInfo startInfo)
        {
            return new ProcessWrapper(startInfo);
        }
    }
}