using Demo.Application.Constract.Interface;
using Demo.Application.CustomException;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Project.Command.UpdateProjectCommand
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, bool>  
    {
        private readonly IRepositoryPattern<Demo.Domain.Entities.Project> _repository;

        public UpdateProjectCommandHandler(IRepositoryPattern<Demo.Domain.Entities.Project> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProjectCommandValidator();
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Count>0)
            {
                throw new ValidationException(validationResult);
            }
            var project=await _repository.GetByIdAsync(request.Id);
            if (project == null)
            {
                throw new NotFoundException("Project not found.", request.Id);
            }
            project.Name = request.Name;    
            project.Description = request.Description;  

            await  _repository.UpdateAsync(project);
          
            return true;
        }
    }
}
