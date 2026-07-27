using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.TaskItem.Query.GetTaskItedDetails
{
    public class GetTaskItedDetailsQuery:IRequest<GetTaskItedDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
