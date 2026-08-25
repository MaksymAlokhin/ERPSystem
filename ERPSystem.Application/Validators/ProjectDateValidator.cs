using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ERPSystem.Domain.Entities;

namespace ERPSystem.Application.Validators
{
    public class ProjectDateValidator : AbstractValidator<Project>
    {
        public ProjectDateValidator()
        {
            RuleFor(m => m.StartDate)
                                .LessThan(m => m.EndDate)
                                .WithMessage("Start date must be before End date");

            RuleFor(m => m.EndDate)
                                .GreaterThan(m => m.StartDate)
                                .WithMessage("End date must be after Start date");
        }
    }
}
