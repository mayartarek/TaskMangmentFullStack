using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Project.Command.DeleteProjectCommand
{
    public class DeleteProjectCommand:IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
