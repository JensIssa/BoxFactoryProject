using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class BoxValidator : AbstractValidator<PostBoxDTO>
{
    public BoxValidator()
    {
        RuleFor(b => b.id).NotEmpty();
        RuleFor(b => b.boxName).NotEmpty();
        RuleFor(b => b.heigth).GreaterThanOrEqualTo(1);
        RuleFor(b => b.length).GreaterThanOrEqualTo(1);
        RuleFor(b => b.width).GreaterThanOrEqualTo(1);
        RuleFor(b => b.imageUrl).NotEmpty();
        RuleFor(b => b.description).NotEmpty();
    }
}