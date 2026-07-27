using Demo.Application.Constract.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Project.Query.GetProjectListLookup
{
    public class GetProjectListLookupQueryHandler : IRequestHandler<GetProjectListLookupQuery, List<ProjectLookupDto>>
    {
        private readonly IRepositoryPattern<Domain.Entities.Project> _repository;

        public GetProjectListLookupQueryHandler(IRepositoryPattern<Domain.Entities.Project> repository)
        {
           _repository = repository;
        }
        public async Task<List<ProjectLookupDto>> Handle(GetProjectListLookupQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllAsync();
            var projectLookupDtos = projects.Select(p => new ProjectLookupDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
            return projectLookupDtos;
        }
    }
}
