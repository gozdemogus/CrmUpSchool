using System;
using CrmUpSchool.EntityLayer.Concrete;
using FluentValidation;

namespace CrmUpSchool.BusinessLayer.ValidationRules
{
	public class AnnouncementValidator:AbstractValidator<Announcement>
	{
		public AnnouncementValidator()
		{
			RuleFor(x => x.Title).NotEmpty().WithMessage("Baslık alanı bos gecilemez.");
			RuleFor(x => x.Content).NotEmpty().WithMessage("İcerik alanı bos gecilemez.");
			RuleFor(x => x.Title).MinimumLength(5).WithMessage("Min 5 karakter giriniz");
			RuleFor(x => x.Title).MaximumLength(20).WithMessage("Max 20 karakter girilebilir.");
		}
	}
}

