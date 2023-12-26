using FluentValidation;
using PustokOnion202.Application.DTOs.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Application.Validators
{
    public class AuthorCreateDtoValidator : AbstractValidator<CreateAuthorDto>
    {
        public AuthorCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).Matches(@"^[a-zA-Z0-9\s]*$").MinimumLength(3);
        }
    }
}
