using Almaz.AssetManagement.Domain;
using Almaz.AssetManagement.Web.Endpoints.CategoriesEndpoints.ViewModel;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Almaz.AssetManagement.Web.Endpoints.CategoriesEndpoints.Queries
{
    public record CategoryCreateRequest(CategoryCreateViewModel Model) : 
        IRequest<OperationResult<CategoryCreateRequest>>;

    public class CategoryCreateRequestHandler : 
        IRequestHandler<CategoryCreateRequest, OperationResult<CategoryCreateRequest>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryCreateRequestHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<CategoryCreateRequest>> Handle
            (
            CategoryCreateRequest request, 
            CancellationToken cancellationToken)
        {
            var operation = OperationResult.CreateResult<CategoryViewModel>();
            var repository = _unitOfWork.GetRepository<Category>();

            var category = new Category
            {
                Name = request.Model.Name,
                Description= request.Model.Description,
            };

            await repository.InsertAsync(category, cancellationToken);

            if(!_unitOfWork.LastSaveChangesResult.IsOk)
            {
                operation.AddError(_unitOfWork.LastSaveChangesResult.Exception?? new CatalogDataBaseSaveExaption()
            }
        }
    }

    [Serializable]
    internal class CatalogDataBaseSaveExaption : Exception
    {
        public CatalogDataBaseSaveExaption()
        {
        }

        public CatalogDataBaseSaveExaption(string? message) : base(message)
        {
        }

        public CatalogDataBaseSaveExaption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CatalogDataBaseSaveExaption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
