namespace Administrator.at.DocuflairConnector.Models
{
    public class PublicInfoModel : ModelBase
    {
        public string TargetUrl { get; set; }
        public bool DisplayOnProductDetail { get; set; }
        public bool DisplayInCheckout { get; set; }
        public bool IsProductDetail { get; set; }
        public bool IsInInCheckout { get; set; }
    }
}
