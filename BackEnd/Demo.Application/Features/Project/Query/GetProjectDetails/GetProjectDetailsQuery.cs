using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Project.Query.GetProjectDetails
{
    public class GetProjectDetailsQuery:IRequest<GetProjectDetailsDto>
    {
        public Guid Id { get; set; }
    }   
    
}
