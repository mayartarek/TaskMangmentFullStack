using Demo.Application.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Application.Features.TaskItem.Query.GetTaskListByStatus
{
    public class GetTaskListByStatusQuery : IRequest<PaginationList<GetTaskListByStatusDto>>
    {
        public Domain.Enums.TaskStatus? TaskStatus { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
