using Demo.Application.Constract.Interface;
using Demo.Application.CustomException;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.TaskItem.Command.DeleteTaskItemCommand
{
    public class DeleteTaskItemCommandHandler : IRequestHandler<DeleteTaskItemCommand, bool>
    {
        private readonly IRepositoryPattern<Domain.Entities.TaskItem> _repository;

        public DeleteTaskItemCommandHandler(IRepositoryPattern<Domain.Entities.TaskItem> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteTaskItemCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _repository.GetByIdAsync(request.Id);
            if (taskItem == null)
            {
                throw new NotFoundException("Task item not found", request.Id);
            }
            await _repository.DeleteAsync(taskItem);
            return true;
        }
    }
}
