using Demo.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskStatus = Demo.Domain.Enums.TaskStatus;

namespace Demo.Application.Features.TaskItem.Command.ChangeTaskItemStatus
{
    public class ChangeTaskItemStatusCommand:IRequest<bool>
    {
        public Guid Id { get; set; }
        public TaskStatus Status { get; set; }
    }
}
