using System.Collections.Generic;
using infosecSoft.infosecPDF.Core.Settings.Enums;
using infosecSoft.infosecPDF.Shared.Helper;
using pdfforge.DynamicTranslator;

namespace infosecSoft.infosecPDF.Shared.ViewModels.UserControls
{
    public class ImageFormatsTabViewModel : CurrentProfileViewModel
    {
        private static readonly TranslationHelper TranslationHelper = TranslationHelper.Instance;

        public static IEnumerable<EnumValue<JpegColor>> JpegColorValues =>
            TranslationHelper.TranslatorInstance.GetEnumTranslation<JpegColor>();

        public static IEnumerable<EnumValue<PngColor>> PngColorValues =>
            TranslationHelper.TranslatorInstance.GetEnumTranslation<PngColor>();

        public static IEnumerable<EnumValue<TiffColor>> TiffColorValues =>
            TranslationHelper.TranslatorInstance.GetEnumTranslation<TiffColor>();
    }
}