using Demo.Application.Constract.Interface;
using Demo.Application.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Project.Query.GetProjectList
{
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, PaginationList<GetProjectListVm>>
    {
        private readonly IRepositoryPattern<Domain.Entities.Project> _repository;

        public GetProjectListQueryHandler(IRepositoryPattern<Domain.Entities.Project> repository)
        {
            _repository = repository;
        }
        public async Task<PaginationList<GetProjectListVm>> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            var query =await _repository.GetAllPagedAsync(request.pageIndex, request.pageSize);
            var result = new PaginationList<GetProjectListVm>
            {
                List = query.Select(x => new GetProjectListVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList(),
                Page = request.pageIndex,
                Size = request.pageSize,
                Count = await _repository.GetTotalCountAsync()
            };
            return result;
        }
    }
}
