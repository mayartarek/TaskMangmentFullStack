using Demo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.TaskItem.Query.GetTaskListByStatus
{
    public class GetTaskListByStatusDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Domain.Enums.TaskStatus Status { get; set; }  
    }
}
