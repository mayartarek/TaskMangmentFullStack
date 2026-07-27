using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Project.Command.CreateProjectCommand
{
    public class CreateProjectCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
