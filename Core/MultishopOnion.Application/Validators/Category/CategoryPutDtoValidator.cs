using FluentValidation;
using MultishopOnion.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Application.Validators.Category
{
    public class CategoryPutDtoValidator:AbstractValidator<CategoryPutDto>
    {
        public CategoryPutDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(3).MaximumLength(100);
        }
    }
}
