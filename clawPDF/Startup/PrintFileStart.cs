﻿using System.IO;
using infosecSoft.infosecPDF.Helper;
using infosecSoft.infosecPDF.Assistants;
using NLog;

namespace infosecSoft.infosecPDF.Startup
{
    internal class PrintFileStart : IAppStart
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public PrintFileStart(string printFile, string printerName)
        {
            PrintFile = printFile;
            PrinterName = printerName;
        }

        public string PrintFile { get; }
        public string PrinterName { get; }

        public bool Run()
        {
            // SettingsHelper.Settings.ConversionProfiles[0].AutoSave.TargetDirectory = "C:\\Users\\CHM\\Desktop111";
            // SettingsHelper.SaveSettings();

            _logger.Info("Launched printjob with PrintFile command.");

            if (string.IsNullOrEmpty(PrintFile))
            {
                _logger.Error("PrintFile Parameter has no argument");
                return false;
            }

            if (!File.Exists(PrintFile))
            {
                _logger.Error("The file \"{0}\" does not exist!", PrintFile);
                return false;
            }

            var printFileAssistant = new PrintFileAssistant(PrinterName);

            if (!printFileAssistant.AddFile(PrintFile))
            {
                _logger.Warn("The file \"{0}\" is not printable!", PrintFile);
                return false;
            }

            if (!printFileAssistant.PrintAll())
            {
                _logger.Error("The file \"{0}\" could not be printed!", PrintFile);
                return false;
            }

            return true;
        }
    }
}