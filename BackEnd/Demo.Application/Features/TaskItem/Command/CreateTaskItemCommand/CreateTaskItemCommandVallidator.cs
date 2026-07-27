using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.TaskItem.Command.CreateTaskItemCommand
{
    public class CreateTaskItemCommandVallidator:AbstractValidator<CreateTaskItemCommand>
    {
        public CreateTaskItemCommandVallidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Task title is required.")
                .MaximumLength(100).WithMessage("Task title cannot exceed 100 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Task description is required.");

        }
    }
}
