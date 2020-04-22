using System;
using infosecSoft.infosecPDF.Core.Jobs;

namespace infosecSoft.infosecPDF
{
    /// <summary>
    ///     EventArgs class that contains the new JobInfo
    /// </summary>
    public class NewJobInfoEventArgs : EventArgs
    {
        public NewJobInfoEventArgs(IJobInfo jobInfo)
        {
            JobInfo = jobInfo;
        }

        public IJobInfo JobInfo { get; }
    }
}