using Demo.Application.Constract.Interface;
using Demo.Application.CustomException;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.TaskItem.Command.CreateTaskItemCommand
{
    public class CreateTaskItemCommandHandler : IRequestHandler<CreateTaskItemCommand, bool>
    {
        private readonly IRepositoryPattern<Domain.Entities.TaskItem> _repository;

        public CreateTaskItemCommandHandler(IRepositoryPattern<Domain.Entities.TaskItem> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
        {
            var validateor = new CreateTaskItemCommandVallidator();
            var validationResult = validateor.Validate(request);
            if (validationResult.Errors.Count>0)
            {
                throw new ValidationException(validationResult);
            }
            await _repository.AddAsync(new Domain.Entities.TaskItem
            {
                Title = request.Title,
                Description = request.Description,
                ProjectId = request.ProjectId,
                DueDate = request.DueDate
            });
            return true;
        }
    }
}
