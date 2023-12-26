using FluentValidation;
using ProniaOnion202.Application.Dtos;
using PustokOnion202.Application.DTOs.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Application.Validators
{
    public class GenreCreateDtoValidator : AbstractValidator<CreateAuthorDto>
    {
        public GenreCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).Matches(@"^[a-zA-Z0-9\s]*$").MinimumLength(3);
        }
    }
}
