using Demo.Application.Constract.Interface;
using Demo.Application.CustomException;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Project.Command.DeleteProjectCommand
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, bool>
    {
        private readonly IRepositoryPattern<Domain.Entities.Project> _repository;

        public DeleteProjectCommandHandler(IRepositoryPattern<Domain.Entities.Project> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);
            if (project == null)
            {
                throw new NotFoundException("Project not found.", request.Id);
            }
            await _repository.DeleteAsync(project);
            return true;
        }
    }
}
