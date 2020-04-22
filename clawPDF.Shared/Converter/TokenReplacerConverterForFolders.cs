using System;
using System.Globalization;
using System.Windows.Data;
using infosecSoft.infosecPDF.Shared.Helper;
using infosecSoft.infosecPDF.Utilities;
using infosecSoft.infosecPDF.Utilities.Tokens;

namespace infosecSoft.infosecPDF.Shared.Converter
{
    [ValueConversion(typeof(string), typeof(string))]
    public class TokenReplacerConverterForFolders : IValueConverter
    {
        public TokenReplacerConverterForFolders()
        {
            TokenReplacer = TokenHelper.TokenReplacerWithPlaceHolders;
        }

        public TokenReplacer TokenReplacer { get; set; }

        public string Footer { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = value as string;

            if (stringValue == null)
                throw new NotImplementedException();

            stringValue = TokenReplacer.ReplaceTokens(stringValue);

            if (Footer != null)
                stringValue += Footer;

            return FileUtil.Instance.MakeValidFolderName(stringValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}