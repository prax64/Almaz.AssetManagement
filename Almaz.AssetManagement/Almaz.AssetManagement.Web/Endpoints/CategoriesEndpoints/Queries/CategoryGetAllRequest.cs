using Almaz.AssetManagement.Domain;
using Almaz.AssetManagement.Web.Endpoints.CategoriesEndpoints.ViewModel;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz.AssetManagement.Web.Endpoints.CategoriesEndpoints.Queries
{
    public record CategoryGetAllRequest : IRequest<OperationResult<List<CategoryViewModel>>>;

    public class CategoryGetAllRequestHendler : IRequestHandler<CategoryGetAllRequest, OperationResult<List<CategoryViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryGetAllRequestHendler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<List<CategoryViewModel>>> Handle(
            CategoryGetAllRequest request, 
            CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.GetRepository<Category>()
                .GetAllAsync(
                    selector: s=> new CategoryViewModel
                    {
                        Id = s.Id, 
                        Name = s.Name, 
                        Description= s.Description, 
                        ProductCount = s.Products!.Count
                    },
                    predicate: x=>x.Visible,
                    include: i=>i.Include(x=>x.Products!)
                );
            return OperationResult.CreateResult(items.ToList());
        }
    }


}
