using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;

namespace Application.Shelves.Queries.GetShelfById
{
    public sealed record GetShelfByIdQuery(Guid Id) : IQuery<GetShelfByIdResponse> { }
}