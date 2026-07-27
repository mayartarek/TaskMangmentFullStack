using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Project.Command.CreateProjectCommand
{
    public class CreateProjectCommandValidator:AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
                RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Project name is required.")
                    .MaximumLength(100).WithMessage("Project name cannot exceed 100 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Project description is required.");
        }
    }
}
