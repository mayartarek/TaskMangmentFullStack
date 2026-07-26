using Demo.Application.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Project.Query.GetProjectList
{
    public class GetProjectListQuery:IRequest<PaginationList<GetProjectListVm>>
    {
       public int pageIndex { get; set;}  
        public int pageSize { get; set;}
    }
}
