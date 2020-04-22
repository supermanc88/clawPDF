﻿using System.ComponentModel;

namespace infosecSoft.infosecPDF.Core.Settings.Enums
{
    public enum OutputFormat
    {
        [Description("PDF")] Pdf,
        [Description("PDF/A-1b")] PdfA1B,
        [Description("PDF/A-2b")] PdfA2B,
        [Description("PDF/X")] PdfX,
        [Description("JPEG")] Jpeg,
        [Description("PNG")] Png,
        [Description("TIFF")] Tif,
        [Description("Text")] Txt
    }
}