using Application.Bookcases.Commands;
using Application.Bookcases.Commands.CreateBookcase;
using Application.Bookcases.Queries.GetBookcases;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class BookcaseController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateBookcase([FromBody] CreateBookcaseRequest request, CancellationToken cancellationToken)
        {
            CreateBookcaseCommand command = request.Adapt<CreateBookcaseCommand>();
            Guid guid = await Sender.Send(command, cancellationToken);
            return CreatedAtAction(nameof(CreateBookcase), new {guid}, guid);
        }

        [HttpGet, Route("list")]
        public async Task<IActionResult> GetBookcase(CancellationToken cancellationToken)
        {
            GetBookcasesQuery query = new GetBookcasesQuery();
            GetBookcasesResponse response = await Sender.Send(query, cancellationToken);
            return Ok(response);
        }
    }
}