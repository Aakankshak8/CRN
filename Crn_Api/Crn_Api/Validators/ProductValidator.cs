using Crn_Api.DTOs;
using FluentValidation;

namespace Crn_Api.Validators;

public class ProductValidator : AbstractValidator<ProductDto>
{
    public ProductValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty()
            .WithMessage("Product name is required")
            .MaximumLength(100);

        RuleFor(x => x.CreatedBy)
            .NotEmpty()
            .WithMessage("CreatedBy is required");
    }
}