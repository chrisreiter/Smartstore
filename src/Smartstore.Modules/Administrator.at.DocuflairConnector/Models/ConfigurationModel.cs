namespace Administrator.at.DocuflairConnector.Models
{
    [LocalizedDisplay("Plugins.Administrator.at.DocuflairConnector.")]
    public class ConfigurationModel : ModelBase
    {
        [LocalizedDisplay("*QrScanEnabled")]
        public bool QrScanEnabled { get; set; }

        [LocalizedDisplay("*QrGenerationEnabled")]
        public bool QrGenerationEnabled { get; set; }

        [LocalizedDisplay("*GeoDataEnabled")]
        public bool GeoDataEnabled { get; set; }

        [LocalizedDisplay("*CardAuthEnabled")]
        public bool CardAuthEnabled { get; set; }
    }
}