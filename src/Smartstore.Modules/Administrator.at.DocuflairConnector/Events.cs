using Administrator.at.DocuflairConnector.Settings;
using DouglasCrockford.JsMin;
using Microsoft.AspNetCore.Html;
using Smartstore.Core.Widgets;
using Smartstore.Events;
using Smartstore.Web.Components;

namespace Administrator.at.DocuflairConnector
{
    public class Events : IConsumer
    {
        private static readonly Dictionary<Type, string> _interceptableViewComponents = new()
        {
            { typeof(HomeProductsViewComponent), "home_page_after_products" },
            { typeof(RecentlyViewedProductsViewComponent), "after_recently_viewed_products" },
            { typeof(CrossSellProductsViewComponent), "after_cross_sell_products" }
        };

        private readonly DocuflairConnectorSettings _settings;
        private readonly IDocuflairConnectorService _DocuflairConnectorService;
        private readonly IWidgetProvider _widgetProvider;

        public Events(DocuflairConnectorSettings settings, IDocuflairConnectorService DocuflairConnectorService, IWidgetProvider widgetProvider)
        {
            _settings = settings;
            _DocuflairConnectorService = DocuflairConnectorService;
            _widgetProvider = widgetProvider;
        }

        public async Task HandleEventAsync(ViewComponentResultExecutingEvent message)
        {
        }
    }
}