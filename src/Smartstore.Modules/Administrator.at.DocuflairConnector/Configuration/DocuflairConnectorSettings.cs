using Smartstore.Core.Configuration;

namespace Administrator.at.DocuflairConnector.Settings
{
    public class DocuflairConnectorSettings : ISettings
    {
        public bool QrScanEnabled { get; set; }
        public bool QrGenerationEnabled { get; set; }
        public bool CardAuthEnabled { get; set; }
        public bool GeoDataEnabled { get; set; }
    }
}