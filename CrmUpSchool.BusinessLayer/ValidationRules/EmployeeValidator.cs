using System;
using CrmUpSchool.EntityLayer.Concrete;
using FluentValidation;

namespace CrmUpSchool.BusinessLayer.ValidationRules
{
	public class EmployeeValidator:AbstractValidator<Employee>
	{
		public EmployeeValidator()
		{
			RuleFor(x => x.EmployeeName).NotEmpty().WithMessage("Personel adı giriniz.");
			RuleFor(x => x.EmployeeSurname).NotEmpty().WithMessage("Personel soyadı giriniz");
			RuleFor(x => x.EmployeeName).MinimumLength(2).WithMessage("Min 2 karakter girilmelidir");
            RuleFor(x => x.EmployeeName).MaximumLength(20).WithMessage("Max 20 karakter girilmelidir");

        }


    }
}

