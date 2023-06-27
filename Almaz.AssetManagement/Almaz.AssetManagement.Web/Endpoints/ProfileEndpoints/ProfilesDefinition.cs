using Almaz.AssetManagement.Web.Application;
using Almaz.AssetManagement.Web.Definitions.OpenIddict;
using Almaz.AssetManagement.Web.Endpoints.ProfileEndpoints.Queries;
using Almaz.AssetManagement.Web.Endpoints.ProfileEndpoints.ViewModels;
using Calabonga.AspNetCore.AppDefinitions;
using Calabonga.OperationResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Almaz.AssetManagement.Web.Endpoints.ProfileEndpoints
{
    public class ProfilesDefinition : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app)
        {
            app.MapGet("/api/profiles/get-roles", GetRoles);
            app.MapPost("/api/profiles/register", RegisterAccount);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
        [FeatureGroupName("Profiles")]
        private async Task<string> GetRoles([FromServices] IMediator mediator, HttpContext context)
            => await mediator.Send(new GetProfile.Request(), context.RequestAborted);

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [FeatureGroupName("Profiles")]
        private async Task<OperationResult<UserProfileViewModel>> RegisterAccount([FromServices] IMediator mediator, RegisterViewModel model, HttpContext context)
            => await mediator.Send(new RegisterAccount.Request(model), context.RequestAborted);
    }
}