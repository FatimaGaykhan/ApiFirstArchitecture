using System;
using FluentValidation;

namespace Service.DTOs.Admin.Countries
{
	public class CountryEditDto
	{
        public string Name { get; set; }

    }

    public class CountryEditDtoValidator : AbstractValidator<CountryEditDto>
    {
        public CountryEditDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
        }
    }
}

