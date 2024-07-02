using Application.Bookcases.Commands;
using Application.Bookcases.Commands.CreateBookcase;
using Application.Bookcases.Commands.RemoveBookcase;
using Application.Bookcases.Commands.UpdateBookcase;
using Application.Bookcases.Queries.GetBookcaseById;
using Application.Bookcases.Queries.GetBookcases;
using Domain.Entities;
using Domain.Primitives;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Presentation.Controllers
{
    public class BookcaseController : ApiController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ActionName(nameof(CreateBookcaseAsync))]
        public async Task<IActionResult> CreateBookcaseAsync([FromBody] CreateBookcaseRequest request, CancellationToken cancellationToken)
        {
            CreateBookcaseCommand command = request.Adapt<CreateBookcaseCommand>();
            Guid guid = await Sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(CreateBookcaseAsync), guid);
        }

        [HttpGet, Route("{id:Guid}")]
        public async Task<IActionResult> GetBookcaseByIdAsync(Guid id,  CancellationToken cancellationToken)
        {
            GetBookcaseByIdQuery query = new GetBookcaseByIdQuery(id);
            GetBookcaseByIdResponse response = await Sender.Send(query, cancellationToken);
            return Ok(response);
        }

        [HttpGet, Route("list")]
        public async Task<IActionResult> GetBookcasesAsync(ushort page, ushort pageSize, CancellationToken cancellationToken)
        {
            Pagination<Bookcase> pagination = new Pagination<Bookcase>(page, pageSize);
            GetBookcasesQuery query = new GetBookcasesQuery(pagination);
            GetBookcasesResponse response = await Sender.Send(query, cancellationToken);
            return Ok(response.Bookcases);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookcaseAsync([FromBody] UpdateBookcaseRequest request, CancellationToken cancellationToken)
        {
            UpdateBookcaseCommand command = request.Adapt<UpdateBookcaseCommand>();
            Guid result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBookcaseAsync([FromBody] RemoveBookcaseRequest request, CancellationToken cancellationToken)
        {
            RemoveBookcaseCommand command = request.Adapt<RemoveBookcaseCommand>();
            bool result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }


    }
}