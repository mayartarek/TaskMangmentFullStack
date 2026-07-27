using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Project.Query.GetProjectListLookup
{
    public class GetProjectListLookupQuery:IRequest<List<ProjectLookupDto>>
    {
    }
}
