using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.TaskItem.Command.ChangeTaskItemStatus
{
    public class ChangeTaskItemStatusValidator:AbstractValidator<ChangeTaskItemStatusCommand>
    {
        public ChangeTaskItemStatusValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("TaskItem Id is required.")
                .NotEmpty().WithMessage("TaskItem Id is required.");
            RuleFor(x => x.Status).NotNull().WithMessage("TaskItem Status is required.");
        }
    }
}
