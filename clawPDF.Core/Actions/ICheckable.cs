using infosecSoft.infosecPDF.Core.Settings;

namespace infosecSoft.infosecPDF.Core.Actions
{
    internal interface ICheckable
    {
        ActionResult Check(ConversionProfile profile);
    }
}