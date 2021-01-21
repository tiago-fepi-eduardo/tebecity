using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Service.Validation
{
    public class ServiceValidator : AbstractValidator<OrderEntity>
    {
        public ServiceValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("OrderEntity not found the object.");
                    });

            RuleFor(c => c.Latitude)
                .NotEmpty().WithMessage("Latitude necessary to inform.")
                .NotNull().WithMessage("Latitude necessary to inform.");

            RuleFor(c => c.Longitude)
                .NotEmpty().WithMessage("Longitude necessary to inform.")
                .NotNull().WithMessage("Longitude necessary to inform.");

            RuleFor(c => c.OcorrencyId)
                .NotEmpty().WithMessage("OcorrencyId necessary to inform.")
                .NotNull().WithMessage("OcorrencyId necessary to inform.");
        }
    }
}
