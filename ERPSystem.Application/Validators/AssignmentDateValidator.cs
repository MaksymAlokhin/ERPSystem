using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ERPSystem.Domain.Entities;

namespace ERPSystem.Application.Validators
{
    public class AssignmentDateValidator : AbstractValidator<Assignment>
    {
        public AssignmentDateValidator()
        {
            RuleFor(m => m.StartDate)
                                .LessThan(m => m.EndDate)
                                .WithMessage("Start Date must be before End Date");

            RuleFor(m => m.EndDate)
                                .GreaterThan(m => m.StartDate)
                                .WithMessage("End Date must be after Start Date");
        }
    }
}
