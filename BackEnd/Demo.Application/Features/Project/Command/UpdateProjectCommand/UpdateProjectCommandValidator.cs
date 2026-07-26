using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Project.Command.UpdateProjectCommand
{
    public class UpdateProjectCommandValidator:AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
                RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Project name is required.")
                    .MaximumLength(100).WithMessage("Project name cannot exceed 100 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Project description is required.");
            RuleFor(x => x.Id).NotNull().WithMessage("Project Id is required.")
                .NotEmpty().WithMessage("Project Id is required.");
        }
    }
}
