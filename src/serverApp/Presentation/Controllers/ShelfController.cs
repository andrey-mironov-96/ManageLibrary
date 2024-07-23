using Application.DTO;
using Application.Primitives;
using Application.Shelves.Commands.CreateShelf;
using Application.Shelves.Queries.GetShelfById;
using Application.Shelves.Queries.GetShelvesByBookcaseId;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ShelfController : ApiController
    {
        [HttpPost, Route("create-shelf")]
        public async Task<IActionResult> CreateShelf([FromBody] CreateShelfRequest request, CancellationToken cancellationToken)
        {
            CreateShelfCommand command = request.Adapt<CreateShelfCommand>();
            Guid shelfId = await this.Sender.Send(command, cancellationToken);
            return Ok(shelfId);
        }


        [HttpGet, Route("get-shelf")]
        public async Task<IActionResult> GetShelf( Guid id, CancellationToken cancellationToken)
        {
            GetShelfByIdQuery query = new(id);
            GetShelfByIdResponse response = await this.Sender.Send(query, cancellationToken);
            return Ok(response);
        }

        [HttpPost, Route("get-shelves-of-bookcase/{bookcaseId:guid}")]
        public async Task<IActionResult> GetShelvesOfBookcase(Guid bookcaseId, [FromBody] Pagination<ShelfDTO> shelves,  CancellationToken cancellationToken)
        {
            GetShelvesByBookcaseIdQuery query = new(bookcaseId, shelves);
            GetShelvesByBookcaseIdResponse response = await this.Sender.Send(query, cancellationToken);
            return Ok(response);
        }
    }
}