using Administrator.at.DocuflairConnector.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Smartstore.Engine;
using Smartstore.Engine.Builders;

namespace Administrator.at.DocuflairConnector
{
    internal class Startup : StarterBase
    {
        public override void ConfigureServices(IServiceCollection services, IApplicationContext appContext)
        {
            if (appContext.IsInstalled)
            {
                services.AddScoped<IDocuflairConnectorService, DocuflairConnectorService>();

                services.Configure<MvcOptions>(o =>
                {
                    //o.Filters.AddConditional<AddToCartActionFilter>(
                    //    context => context.ControllerIs<ShoppingCartController>(x => x.AddProduct(0, 0, null)));

                    //o.Filters.AddConditional<AddToCartActionFilterResult>(
                    //    context => context.ControllerIs<ShoppingCartController>(x => x.AddProduct(0, 0, null)));
                });
            }
        }
    }
}