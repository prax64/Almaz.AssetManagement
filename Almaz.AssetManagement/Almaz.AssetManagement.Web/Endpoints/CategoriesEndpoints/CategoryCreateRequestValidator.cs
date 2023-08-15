using Almaz.AssetManagement.Web.Endpoints.CategoriesEndpoints.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz.AssetManagement.Web.Endpoints.CategoriesEndpoints
{
    public class CategoryCreateRequestValidator : AbstractValidator<CategoryCreateRequest>
    {
        public CategoryCreateRequestValidator()
        {
            RuleFor(x => x.Model.Name).Length(5, 50);
            RuleFor(x => x.Model.Description).Length(10, 1024);
            RuleFor(x => x.Model.Name).Length(5, 50);
        }
    }
}
