using Demo.Application.Constract.Interface;
using Demo.Application.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.TaskItem.Query.GetTaskListByStatus
{
    public class GetTaskListByStatusQueryHandler : IRequestHandler<GetTaskListByStatusQuery, PaginationList<GetTaskListByStatusDto>>
    {
        private readonly IRepositoryPattern<Domain.Entities.TaskItem> _repository;

        public GetTaskListByStatusQueryHandler(IRepositoryPattern<Domain.Entities.TaskItem> repository)
        {
            _repository = repository;
        }
        public async Task<PaginationList<GetTaskListByStatusDto>> Handle(GetTaskListByStatusQuery request, CancellationToken cancellationToken)
        {
            var query =await _repository.GetAllAsync();
         
            if (request.TaskStatus.HasValue)
            {
                query = query.Where(x => x.Status == request.TaskStatus.Value );
            }
            var taskItems = query.Select(x => new GetTaskListByStatusDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                DueDate = x.DueDate,
                Status = x.Status
            }).Skip((request.Page - 1) * request.Size).Take(request.Size).ToList();
            var result = new PaginationList<GetTaskListByStatusDto>
            {
                List = taskItems,
                Page = request.Page,
                Size = request.Size,
                Count = await _repository.GetTotalCountAsync()
            };
            return result;
        }
    }
}
