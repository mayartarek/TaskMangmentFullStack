using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.TaskItem.Command.CreateTaskItemCommand
{
    public class CreateTaskItemCommand:IRequest<bool>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime DueDate { get; set; }

   
    }
}
