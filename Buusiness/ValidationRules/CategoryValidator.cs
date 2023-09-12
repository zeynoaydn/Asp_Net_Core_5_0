using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buusiness.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("category adı boş geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("category içeriği boş geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("en az 2 karakter içermeli");
            RuleFor(x => x.CategoryName).MaximumLength(300).WithMessage("en fazla 50 karakter içermeli");
        }

    }
}
