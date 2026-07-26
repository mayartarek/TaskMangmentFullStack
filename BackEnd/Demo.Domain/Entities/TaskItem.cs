using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Demo.Domain.Entities
{
    public class TaskItem:BaseEntity
    {
            public string Title { get; set; }

            public string? Description { get; set; }

            public Demo.Domain.Enums.TaskStatus Status { get; set; }

            public DateTime DueDate { get; set; }

            public Guid ProjectId { get; set; }

            public Project Project { get; set; }
        
    }
}
