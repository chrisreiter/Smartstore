using Administrator.at.DocuflairConnector.Settings;
using Microsoft.EntityFrameworkCore;
using Smartstore.Core;
using Smartstore.Core.Catalog.Products;
using Smartstore.Core.Data;
using Smartstore.Core.Identity;

namespace Administrator.at.DocuflairConnector
{
    public class DocuflairConnectorService : IDocuflairConnectorService
    {
        private readonly DocuflairConnectorSettings _settings;
        private readonly Lazy<ICommonServices> _services;
        //private readonly Lazy<IRepository<SparePartListDataRecord>> _spListRepository;
        private readonly Lazy<SmartDbContext> _db;
        private const string cacheKey = "keyTargetShopUrl";

        public Localizer T
        {
            get;
            set;
        } = NullLocalizer.Instance;

        public DocuflairConnectorService(
            DocuflairConnectorSettings settings,
            Lazy<ICommonServices> services,
            //Lazy<IRepository<SparePartListDataRecord>> spListRepository,
            Lazy<SmartDbContext> db
            )
        {
            _settings = settings;
            _services = services;
            //_spListRepository = spListRepository;
            _db = db;
        }
    }
}