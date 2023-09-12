using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buusiness.ValidationRules
{
	public class WriterValidate:AbstractValidator<Writer>
	{
        public WriterValidate()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("yazar adı soyadı boş geçilemez");
            RuleFor(x=>x.WriterMail).NotEmpty().WithMessage("mail adresi boş geçilemez");
            RuleFor(x=>x.WriterPassword).NotEmpty().WithMessage("şifre boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("en az karakter içermeli");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("en fazla 50 karakter içermeli");
		}
    }
}
