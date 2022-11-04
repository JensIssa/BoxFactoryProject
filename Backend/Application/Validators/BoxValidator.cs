using Application.DTOs;
using Domain.Entities;
using FluentValidation;

namespace Application.Validators;

public class BoxValidator : AbstractValidator<PostBoxDTO>
{
    public BoxValidator()
    {
        //RuleFor(b => b.id).NotEmpty();
        RuleFor(b => b.BoxName).NotEmpty();
        RuleFor(b => b.Heigth).GreaterThanOrEqualTo(1);
        RuleFor(b => b.Length).GreaterThanOrEqualTo(1);
        RuleFor(b => b.Width).GreaterThanOrEqualTo(1);
        RuleFor(b => b.ImageUrl).NotEmpty();
        RuleFor(b => b.Description).NotEmpty();
    }

    public class BoxValidator2 : AbstractValidator<PutBoxDTO>
    {
        public BoxValidator2()
        {
            RuleFor(b => b.BoxName).NotEmpty();
            RuleFor(b => b.Heigth).GreaterThanOrEqualTo(1);
            RuleFor(b => b.Length).GreaterThanOrEqualTo(1);
            RuleFor(b => b.Width).GreaterThanOrEqualTo(1);
            RuleFor(b => b.ImageUrl).NotEmpty();
            RuleFor(b => b.Description).NotEmpty();
        }
    }
}