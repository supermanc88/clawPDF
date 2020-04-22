﻿using System;
using System.Collections.Generic;
using infosecSoft.infosecPDF.Core.Actions;
using infosecSoft.infosecPDF.Core.Settings;
using infosecSoft.infosecPDF.Utilities.Tokens;

namespace infosecSoft.infosecPDF.Core.Jobs
{
    /// <summary>
    ///     A Job is the item to do a conversion from a source format to the final file formats like PDF.
    ///     The Job interface defines the methods a Job has to implement.
    /// </summary>
    public interface IJob
    {
        /// <summary>
        ///     The JobInfo class describes the information on this Job, like source files, target file etc.
        /// </summary>
        IJobInfo JobInfo { get; }

        /// <summary>
        ///     The conversion profile to use for this job
        /// </summary>
        ConversionProfile Profile { get; set; }

        /// <summary>
        ///     Holds passwords for encryption etc.
        /// </summary>
        JobPasswords Passwords { get; set; }

        /// <summary>
        ///     Holds translations required during the job
        /// </summary>
        JobTranslations JobTranslations { get; set; }

        /// <summary>
        ///     Set if temporary files hould be cleaned automatically
        /// </summary>
        bool AutoCleanUp { get; set; }

        /// <summary>
        ///     The number of pages the print job has
        /// </summary>
        int NumberOfPages { get; }

        /// <summary>
        ///     The number of copies requested for the print job
        /// </summary>
        int NumberOfCopies { get; }

        /// <summary>
        ///     The Output files that have been generated by this job
        /// </summary>
        IList<string> OutputFiles { get; set; }

        /// <summary>
        ///     The template for the output files. This may contain a wildcard to create multiple files, i.e. a file per page. The
        ///     template is used to constrcut the final output filename.
        /// </summary>
        string OutputFilenameTemplate { get; set; }

        /// <summary>
        ///     The folder in which the job can store temporary data
        /// </summary>
        string JobTempFolder { get; }

        /// <summary>
        ///     The folder in which the job produces the output files
        /// </summary>
        string JobTempOutputFolder { get; }

        /// <summary>
        ///     Temporary filename of the output file
        /// </summary>
        string JobTempFileName { get; }

        /// <summary>
        ///     Flag to skip the SaveFileDialog (Therefore an OutputFilename must be set)
        /// </summary>
        bool SkipSaveFileDialog { get; set; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        TokenReplacer TokenReplacer { get; set; }

        /// <summary>
        ///     Current state of Job
        /// </summary>
        JobState JobState { get; }

        /// <summary>
        ///     If true, the job has completed execution
        /// </summary>
        bool Completed { get; }

        /// <summary>
        ///     If true, the job was successful
        /// </summary>
        bool Success { get; }

        /// <summary>
        ///     An Error message with an internal state of what went wrong. May be untranslated.
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        ///     The type of the Error or JobError.None, if no error happened
        /// </summary>
        JobError ErrorType { get; }

        /// <summary>
        ///     A list of output files produced during the conversion
        /// </summary>
        IList<string> TempOutputFiles { get; set; }

        /// <summary>
        ///     Runs this Job synchronously
        /// </summary>
        JobState RunJob();

        /// <summary>
        ///     Adds an Action to execute when the Job has been finished
        /// </summary>
        /// <param name="action">The Action to execute</param>
        void AddAction(IAction action);

        /// <summary>
        ///     Clean up all temporary files that have been generated during the Job
        /// </summary>
        void CleanUp();

        /// <summary>
        ///     Compose the output filename based on settings, output format etc.
        /// </summary>
        /// <returns>composed output filename</returns>
        string ComposeOutputFilename();

        /// <summary>
        ///     Applies Metadata to the current job
        /// </summary>
        void ApplyMetadata();

        /// <summary>
        ///     Inits Metadata for the current job
        /// </summary>
        void InitMetadata();

        /// <summary>
        ///     Renames and moves all files from TempOutputFiles to their destination according to
        ///     the FilenameTemplate and stores them in the OutputFiles list.
        ///     For multiple files the FilenameTemplate gets an appendix.
        /// </summary>
        void MoveOutputFiles();

        /// <summary>
        ///     Collect all output files for this device from tempFolder.
        /// </summary>
        void CollectTemporaryOutputFiles();

        event EventHandler<ActionAddedEventArgs> OnActionAdded;

        event JobEvent.EvaluateActionResult OnEvaluateActionResult;

        event EventHandler<QueryPasswordEventArgs> OnRetypeSmtpPassword;

        event EventHandler<QueryFilenameEventArgs> OnRetypeOutputFilename;

        event EventHandler<JobCompletedEventArgs> OnJobCompleted;

        event EventHandler<JobProgressChangedEventArgs> OnJobProgressChanged;
    }

    public class JobEvent
    {
        public delegate bool EvaluateActionResult(ActionResult actionResult);
    }

    public class JobResultEventArgs : EventArgs
    {
        public JobResultEventArgs(ActionResult actionResult)
        {
            ActionResult = actionResult;
        }

        public ActionResult ActionResult { get; set; }
    }

    public class QueryFilenameEventArgs : EventArgs
    {
        public QueryFilenameEventArgs(IJob job)
        {
            Job = job;
        }

        public IJob Job { get; }
        public bool Cancelled { get; set; }
    }

    public class QueryPasswordEventArgs : EventArgs
    {
        public QueryPasswordEventArgs(IJob job)
        {
            Job = job;
        }

        public IJob Job { get; set; }
        public bool Cancel { get; set; }
    }

    public class FixInvalidFilenameEventArgs : EventArgs
    {
        public FixInvalidFilenameEventArgs(IJob job)
        {
            Job = job;
        }

        public IJob Job { get; set; }
        public bool Cancel { get; set; }
    }

    public class ActionAddedEventArgs : EventArgs
    {
        public ActionAddedEventArgs(IJob job, IAction action)
        {
            Job = job;
            Action = action;
            SkipAction = false;
        }

        public IJob Job { get; }
        public IAction Action { get; }
        public bool SkipAction { get; set; }
    }

    public class JobCompletedEventArgs : EventArgs
    {
        public JobCompletedEventArgs(IJob job)
        {
            Job = job;
        }

        public IJob Job { get; }
    }

    public class JobProgressChangedEventArgs : EventArgs
    {
        public JobProgressChangedEventArgs(IJob job, int progressPercentage)
        {
            Job = job;
            ProgressPercentage = progressPercentage;
        }

        public IJob Job { get; }
        public int ProgressPercentage { get; }
    }
}