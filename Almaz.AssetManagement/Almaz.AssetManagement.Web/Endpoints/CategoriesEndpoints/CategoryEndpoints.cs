using Almaz.AssetManagement.Web.Application;
using Almaz.AssetManagement.Web.Endpoints.CategoriesEndpoints.Queries;
using Calabonga.AspNetCore.AppDefinitions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Almaz.AssetManagement.Web.Endpoints.CategoriesEndpoints
{
    public class CategoryEndpoints : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app)
        {
            app.MapGet("/api/catalogs/get-all", GetAll);

        }

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [FeatureGroupName("Catigories")]
        private Task GetAll([FromServices] IMediator mediator, HttpContext context)
        {
            return mediator.Send(new CategoryGetAllRequest(), context.RequestAborted);
        }
    }
}
