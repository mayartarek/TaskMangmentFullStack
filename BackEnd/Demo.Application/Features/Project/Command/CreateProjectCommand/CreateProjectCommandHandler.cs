using Demo.Application.Constract.Interface;
using Demo.Application.CustomException;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Project.Command.CreateProjectCommand
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, bool>  
    {
        private readonly IRepositoryPattern<Demo.Domain.Entities.Project> _repository;

        public CreateProjectCommandHandler(IRepositoryPattern<Demo.Domain.Entities.Project> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProjectCommandValidator();
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Count>0)
            {
                throw new ValidationException(validationResult);
            }
            await _repository.AddAsync(new Demo.Domain.Entities.Project
            {
                Name = request.Name,
                Description = request.Description,
            });
            return true;
        }
    }
}
