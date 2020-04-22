﻿using System;

namespace infosecSoft.infosecPDF.PDFProcessing
{
    public class ProcessingException : Exception
    {
        public ProcessingException(string message, int errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public int ErrorCode { get; }
    }
}