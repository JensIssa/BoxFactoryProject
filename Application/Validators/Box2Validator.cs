using Domain.Entities;
using FluentValidation;

namespace Application.Validators;

public class Box2Validator : AbstractValidator<Box>
{
    public Box2Validator()
    {
        RuleFor(b => b.Id).NotEmpty();
    }
}