using System;
using CrmUpSchool.DTOLayer.DTOs.ContactDTOs;
using FluentValidation;

namespace CrmUpSchool.BusinessLayer.ValidationRules.ContactValidation
{
	public class ContactAddValidator:AbstractValidator<ContactAddDto>
	{
		public ContactAddValidator()
		{
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail boş geçilemez!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Mesaj boş geçilemez!");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Lütfen en az 5 karakter yazınız.");
            RuleFor(x => x.Name).MaximumLength(5).WithMessage("En fazla 50 karakter yazınız.");
            RuleFor(x => x.Subject).MinimumLength(50).WithMessage("Lütfen en az 5 karakter yazınız.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En fazla 100 larakter yazınız.");
        }


	}
}

