using FluentValidation;
using MultishopOnion.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Application.Validators
{
    public class CategoryPostDtoValidator:AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(3).MaximumLength(100);
        }
    }
}
