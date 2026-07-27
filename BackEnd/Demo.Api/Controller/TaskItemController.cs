using Demo.Application.Features.TaskItem.Command.DeleteTaskItemCommand;
using Demo.Application.Features.TaskItem.Query.GetTaskItedDetails;
using Demo.Application.Features.TaskItem.Query.GetTaskItemList;
using Demo.Application.Helper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// creates a new task item
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateTaskItem([FromBody] Demo.Application.Features.TaskItem.Command.CreateTaskItemCommand.CreateTaskItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// updates an existing task item
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateTaskItem([FromBody] Demo.Application.Features.TaskItem.Command.UpdateTaskItemCommand.UpdateTaskItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// updates the status of an existing task item
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("updateTaskStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateTaskStatus([FromBody] Demo.Application.Features.TaskItem.Command.ChangeTaskItemStatus.ChangeTaskItemStatusCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// deletes an existing task item
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
       public async Task<IActionResult> DeleteTaskItem([FromBody] DeleteTaskItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("TaskItems")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(PaginationList<GetTaskItemListDto>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PaginationList<GetTaskItemListDto>>> GetAll([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] Guid? projectId = null)
        {
            var response = await _mediator.Send(new GetTaskItemListQuery() { Page = page, Size = pageSize, ProjectId = projectId });

            return Ok(response);
        }
        [HttpGet("TaskItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetTaskItedDetailsDto), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetTaskItedDetailsDto>> GetById([FromQuery] Guid id)
        {
            var response = await _mediator.Send(new GetTaskItedDetailsQuery() { Id = id });
            return Ok(response);    
        }
    }
}
