using Almaz.AssetManagement.Web.Application;
using Almaz.AssetManagement.Web.Definitions.OpenIddict;
using Almaz.AssetManagement.Web.Endpoints.CategoriesEndpoints.Queries;
using Almaz.AssetManagement.Web.Endpoints.CategoriesEndpoints.ViewModel;
using Calabonga.AspNetCore.AppDefinitions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Almaz.AssetManagement.Web.Endpoints.CategoriesEndpoints
{
    public class CategoryEndpoints : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app)
        {
            app.MapGet("/api/catalogs/get-all", GetAllCategories);
            app.MapPost("/api/catalogs/create", CreateCategory);


        }

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [FeatureGroupName("Catigories")]
        private Task GetAllCategories([FromServices] IMediator mediator, HttpContext context)
        {
            return mediator.Send(new CategoryGetAllRequest(), context.RequestAborted);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [FeatureGroupName("Catigories")]
        [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
        private async Task<IResult> CreateCategory(
            [FromServices] IMediator mediator, 
            [FromBody] CategoryCreateViewModel createViewModel, 
            HttpContext context)
        {
            var operation = await mediator.Send(new CategoryCreateRequest(createViewModel), context.RequestAborted);
            if(operation.Ok)
            {
                return TypedResults.Created($"/api/categories/{operation.Result!.Id}", operation.Result);
            }
            return TypedResults.BadRequest();
        }
    }
}
