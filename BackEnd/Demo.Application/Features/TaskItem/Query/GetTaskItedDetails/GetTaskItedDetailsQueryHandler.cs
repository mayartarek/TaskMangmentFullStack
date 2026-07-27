using Demo.Application.Constract.Interface;
using Demo.Application.CustomException;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.TaskItem.Query.GetTaskItedDetails
{
    public class GetTaskItedDetailsQueryHandler : IRequestHandler<GetTaskItedDetailsQuery, GetTaskItedDetailsDto>
    {
        private readonly IRepositoryPattern<Domain.Entities.TaskItem> _repository;

        public GetTaskItedDetailsQueryHandler(IRepositoryPattern<Domain.Entities.TaskItem> repository)
        {
            _repository = repository;
        }
        public async Task<GetTaskItedDetailsDto> Handle(GetTaskItedDetailsQuery request, CancellationToken cancellationToken)
        {
            var taskItem = await _repository.GetByIdAsync(request.Id);
            if (taskItem == null)
            {
                throw new NotFoundException("Task item not found", request.Id);
            }
            var taskItemDetailsDto = new GetTaskItedDetailsDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                DueDate = taskItem.DueDate,
                Status = taskItem.Status
            };
            return taskItemDetailsDto;
        }
    }
}
