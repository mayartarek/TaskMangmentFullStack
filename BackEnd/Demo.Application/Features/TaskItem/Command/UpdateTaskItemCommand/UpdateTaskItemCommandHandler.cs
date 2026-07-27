using Demo.Application.Constract.Interface;
using Demo.Application.CustomException;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.TaskItem.Command.UpdateTaskItemCommand

{
    public class UpdateTaskItemCommandHandler : IRequestHandler<UpdateTaskItemCommand, bool>
    {
        private readonly IRepositoryPattern<Domain.Entities.TaskItem> _repository;

        public UpdateTaskItemCommandHandler(IRepositoryPattern<Domain.Entities.TaskItem> repository) 
        {
            _repository = repository;
        }
        public async Task<bool> Handle(UpdateTaskItemCommand request, CancellationToken cancellationToken)
        {
            var validateor = new UpdateTaskItemCommandVallidator();
            var validationResult = validateor.Validate(request);
            if (validationResult.Errors.Count>0)
            {
                throw new ValidationException(validationResult);
            }
            var taskItem = await _repository.GetByIdAsync(request.Id);
            if (taskItem == null) 
                throw new NotFoundException("TaskItem isnot found.", request.Id);
            taskItem.Title = request.Title;
            taskItem.Description = request.Description;
            taskItem.DueDate = request.DueDate; 

            await _repository.UpdateAsync(taskItem);
            return true;
        }
    }
}
