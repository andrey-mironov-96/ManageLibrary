using Application.Features.Books.Commands.CreateBook;
using Application.Features.Books.Queries.GetBookById;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public sealed class BookController : ApiController
    {
        [HttpGet("{bookId:guid}")]
        [ProducesResponseType(typeof(BookResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBook(Guid bookId, CancellationToken cancellationToken)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(bookId);
            BookResponse book = await Sender.Send(query, cancellationToken);
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBook(
        [FromBody] CreateBookRequest request,
        CancellationToken cancellationToken)
        {
            CreateBookCommand command = request.Adapt<CreateBookCommand>();

            Guid bookId = await Sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(CreateBook), new { bookId }, bookId);
        }
    }
}
