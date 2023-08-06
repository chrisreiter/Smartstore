using Administrator.at.DocuflairConnector.Models;
using Administrator.at.DocuflairConnector.Settings;
using Microsoft.AspNetCore.Mvc;
using Smartstore.ComponentModel;
using Smartstore.Core;
using Smartstore.Core.Security;
using Smartstore.Web.Controllers;
using Smartstore.Web.Modelling.Settings;
using Smartstore.Core.Widgets;
using Smartstore.Core.Checkout.Cart;
using Smartstore.Core.Identity;
using Smartstore.Engine.Modularity;
using Smartstore.Core.Catalog.Attributes;
using Smartstore.Core.Data;
using Smartstore.Imaging.Barcodes;
using Smartstore.Imaging;
using System.IO;
using System.Net.Mime;

namespace Administrator.at.DocuflairConnector.Controllers
{
    //[Area("Admin")]
    public class DocuflairConnectorController : PublicController
    {
        private readonly SmartDbContext _db;
        private readonly Lazy<CatalogHelper> _helper;
        private readonly Lazy<IBarcodeEncoder> _encoder;
        private readonly Lazy<IDocuflairConnectorService> _dfService;

        public DocuflairConnectorController(SmartDbContext db, Lazy<CatalogHelper> helper, Lazy<IBarcodeEncoder> encoder, Lazy<IDocuflairConnectorService> dfService)
        {
            _db = db;
            _helper = helper;
            _encoder = encoder;
            _dfService = dfService;
        }

        #region public info / widget rendering


        #endregion
    }
}
