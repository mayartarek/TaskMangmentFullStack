using Demo.Application.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.TaskItem.Query.GetTaskItemList
{
    public class GetTaskItemListQuery : IRequest<PaginationList<GetTaskItemListDto>>
    {
        public Guid? ProjectId { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
