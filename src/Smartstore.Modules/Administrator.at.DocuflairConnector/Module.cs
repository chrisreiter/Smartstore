global using System;
global using System.Collections.Generic;
global using System.ComponentModel.DataAnnotations;
global using System.Linq;
global using System.Threading.Tasks;
global using Smartstore.Core.Localization;
global using Smartstore.Web.Modelling;
using Administrator.at.DocuflairConnector.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Smartstore.Core.Identity;
using Smartstore.Core.Widgets;
using Smartstore.Engine.Modularity;
using Smartstore.Http;

namespace Administrator.at.DocuflairConnector
{
    internal class Module : ModuleBase, IConfigurable, IActivatableWidget, ICookiePublisher
    {
        private readonly IProviderManager _providerManager;
        private readonly WidgetSettings _widgetSettings;

        public Module(IProviderManager providerManager, WidgetSettings widgetSettings)
        {
            _providerManager = providerManager;
            _widgetSettings = widgetSettings;
        }

        public ILogger Logger { get; set; } = NullLogger.Instance;
        public Localizer T { get; set; } = NullLocalizer.Instance;

        public RouteInfo GetConfigurationRoute()
            => new("Configure", "DocuflairConnectorAdmin", new { area = "Admin" });

        public Task<IEnumerable<CookieInfo>> GetCookieInfosAsync()
        {
            var widget = _providerManager.GetProvider<IActivatableWidget>("Administrator.at.DocuflairConnector");
            if (!widget.IsWidgetActive(_widgetSettings))
                return Task.FromResult(Enumerable.Empty<CookieInfo>());

            var cookieInfo = new CookieInfo
            {
                Name = T("Plugins.FriendlyName.Administrator.at.DocuflairConnector"),
                Description = T("Plugins.Widgets.DocuflairConnector.CookieInfo"),
                CookieType = CookieType.Required
            };

            return Task.FromResult(new CookieInfo[] { cookieInfo }.AsEnumerable());
        }

        public Widget GetDisplayWidget(string widgetZone, object model, int storeId)
        {
            //if (widgetZone == "content_before")
            //{
            //    return new ComponentWidget(typeof(ScanButtonViewComponent), model);
            //}
            ////else if (widgetZone == "productdetails_pictures_bottom")
            //return new ComponentWidget(typeof(PrintQrButtonViewComponent), model);

            return null;
        }

        public string[] GetWidgetZones() => new[] { "content_before", "productdetails_pictures_bottom" };

        public override async Task InstallAsync(ModuleInstallationContext context)
        {
            await ImportLanguageResourcesAsync();
            await TrySaveSettingsAsync(new DocuflairConnectorSettings());
            await base.InstallAsync(context);
        }

        public override async Task UninstallAsync()
        {
            await DeleteLanguageResourcesAsync();
            await DeleteSettingsAsync<DocuflairConnectorSettings>();
            await base.UninstallAsync();
        }
    }
}