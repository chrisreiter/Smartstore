using Administrator.at.DocuflairConnector.Models;
using Administrator.at.DocuflairConnector.Settings;
using Microsoft.AspNetCore.Mvc;
using Smartstore.ComponentModel;
using Smartstore.Core;
using Smartstore.Core.Security;
using Smartstore.Web.Controllers;
using Smartstore.Web.Modelling.Settings;
using Smartstore.Core.Widgets;
using Smartstore.Engine.Modularity;

namespace Administrator.at.DocuflairConnector.Controllers
{
    public class DocuflairConnectorAdminController : AdminController
    {
        private readonly WidgetSettings _widgetSettings;
        private readonly IWidgetService _widgetService;
        private readonly IProviderManager _providerManager;

        public DocuflairConnectorAdminController(WidgetSettings widgetSettings, IWidgetService widgetService, IProviderManager providerManager)
        {
            _widgetSettings = widgetSettings;
            _widgetService = widgetService;
            _providerManager = providerManager;
        }

        [LoadSetting]
        public IActionResult Configure(DocuflairConnectorSettings settings)
        {
            var model = MiniMapper.Map<DocuflairConnectorSettings, ConfigurationModel>(settings);
            return View(model);
        }

        [HttpPost, SaveSetting]
        public async Task<IActionResult> Configure(ConfigurationModel model, DocuflairConnectorSettings settings)
        {
            if (!ModelState.IsValid)
            {
                return Configure(settings);
            }

            var prevState = settings.QrScanEnabled;
            ModelState.Clear();
            MiniMapper.Map(model, settings);

            if (model.QrScanEnabled && !prevState)
            {
                var widget = _providerManager.GetProvider<IActivatableWidget>("Administrator.at.DocuflairConnector");
                if (!widget.IsWidgetActive(_widgetSettings))
                {
                    await _widgetService.ActivateWidgetAsync("Administrator.at.DocuflairConnector", true);
                }
            }

            NotifySuccess(T("Admin.Common.DataSuccessfullySaved"));

            return RedirectToAction(nameof(Configure));
        }
    }
}