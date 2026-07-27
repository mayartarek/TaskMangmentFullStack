using Demo.Application.Constract.Interface;
using Demo.Application.CustomException;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.TaskItem.Command.ChangeTaskItemStatus
{
    public class ChangeTaskItemStatusCommandHandler:IRequestHandler<ChangeTaskItemStatusCommand, bool>
    {
        private readonly IRepositoryPattern<Domain.Entities.TaskItem> _repository;

        public ChangeTaskItemStatusCommandHandler(IRepositoryPattern<Domain.Entities.TaskItem> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ChangeTaskItemStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new ChangeTaskItemStatusValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if(validationResult.Errors.Count>0)
                throw new ValidationException(validationResult);
            var taskItem = await _repository.GetByIdAsync(request.Id);
            if (taskItem == null)
                throw new NotFoundException("Task item not found",request.Id);

            taskItem.Status = request.Status;
            await _repository.UpdateAsync(taskItem);
            return true;    
        }
    }
}
