using Almaz.AssetManagement.Web.Definitions.Mediator.Base;
using Almaz.AssetManagement.Web.Endpoints.EventItemsEndpoints.ViewModels;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;
using MediatR;

namespace Almaz.AssetManagement.Web.Definitions.Mediator
{
    public class EventItemPostTransactionBehavior : TransactionBehavior<IRequest<OperationResult<EventItemViewModel>>, OperationResult<EventItemViewModel>>
    {
        public EventItemPostTransactionBehavior(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}