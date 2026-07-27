using Demo.Application.Constract.Interface;
using Demo.Application.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.TaskItem.Query.GetTaskItemList
{
    public class GetTaskItemListQueryHandler : IRequestHandler<GetTaskItemListQuery, PaginationList<GetTaskItemListDto>>
    {
        private readonly IRepositoryPattern<Domain.Entities.TaskItem> _repository;

        public GetTaskItemListQueryHandler(IRepositoryPattern<Domain.Entities.TaskItem> repository)
        {
            _repository = repository;
        }
        public async Task<PaginationList<GetTaskItemListDto>> Handle(GetTaskItemListQuery request, CancellationToken cancellationToken)
        {
            var query =await _repository.GetAllAsync();
            if (request.ProjectId.HasValue)
            {
                query = query.Where(x => x.ProjectId == request.ProjectId.Value);
            }
            var taskItems = query.Select(x => new GetTaskItemListDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                DueDate = x.DueDate,
                Status = x.Status
            }).Skip((request.Page - 1) * request.Size).Take(request.Size).ToList();
            var result = new PaginationList<GetTaskItemListDto>
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
