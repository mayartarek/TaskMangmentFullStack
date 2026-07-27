using Demo.Application.Features.Project.Command.CreateProjectCommand;
using Demo.Application.Features.Project.Command.DeleteProjectCommand;
using Demo.Application.Features.Project.Command.UpdateProjectCommand;
using Demo.Application.Features.Project.Query.GetProjectDetails;
using Demo.Application.Features.Project.Query.GetProjectList;
using Demo.Application.Features.Project.Query.GetProjectListLookup;
using Demo.Application.Features.TaskItem.Query.GetTaskListByStatus;
using Demo.Application.Helper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
           _mediator = mediator;
        }
        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        ///  updates an existing project.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// Deletes an existing project.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteProject([FromQuery] Guid id)
        {
            var result = await _mediator.Send(new DeleteProjectCommand { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("Projects")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(PaginationList<GetProjectListVm>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PaginationList<GetProjectListVm>>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var response = await _mediator.Send(new GetProjectListQuery() { pageIndex = page, pageSize = pageSize });

            return Ok(response);
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Project")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetProjectDetailsDto), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetProjectDetailsDto>> GetById([FromQuery] Guid id)
        {
            var response = await _mediator.Send(new GetProjectDetailsQuery() { Id = id });
            return Ok(response);
        }
        [HttpGet("LookUp")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<ProjectLookupDto>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ProjectLookupDto>>> GetLookUp()
        {
            var response = await _mediator.Send(new GetProjectListLookupQuery());
            return Ok(response);
        }
    }
}
