using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Entities
{
    public class Project:BaseEntity
    {
        public string Name { get; set; }    
        public string Description { get; set; } 
        public virtual List<TaskItem> TaskItems { get; set; } 
    }
}
