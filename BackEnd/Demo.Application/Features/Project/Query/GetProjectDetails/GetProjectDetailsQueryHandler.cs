using Demo.Application.Constract.Interface;
using Demo.Application.CustomException;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Project.Query.GetProjectDetails
{
    public class GetProjectDetailsQueryHandler : IRequestHandler<GetProjectDetailsQuery, GetProjectDetailsDto>
    {
        private readonly IRepositoryPattern<Domain.Entities.Project> _repository;

        public GetProjectDetailsQueryHandler(IRepositoryPattern<Domain.Entities.Project> repository)
        {
            _repository = repository;
        }
        public async Task<GetProjectDetailsDto> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
        {
            var project =await _repository.GetByIdAsync(request.Id);
            if (project == null)
            {
                throw new NotFoundException("Project isnot found.",request.Id);
            }
            return new GetProjectDetailsDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            };
        }
    }
}
