using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buusiness.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("blog başlığı boş geçilemez");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("blog içeriği boş geçilemez");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("resim boş geçilemez");
            RuleFor(x => x.BlogTitle).MinimumLength(2).WithMessage("en az 2 karakter içermeli");
            RuleFor(x => x.BlogTitle).MaximumLength(300).WithMessage("en fazla 50 karakter içermeli");
        }

    }
}
