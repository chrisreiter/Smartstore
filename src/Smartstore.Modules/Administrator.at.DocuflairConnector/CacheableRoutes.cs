using Smartstore.Core.OutputCache;

namespace Administrator.at.DocuflairConnector
{
    internal sealed class CacheableRoutes : ICacheableRouteProvider
    {
        public int Order => 0;

        public IEnumerable<string> GetCacheableRoutes()
        {
            return new string[]
            {
                "vc:Administrator.at.DocuflairConnector/DocuflairConnector"
            };
        }
    }
}
