using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Shelves.Queries.GetShelfById
{
    public sealed record GetShelfByIdResponse(Guid Id, ushort Number, ushort CountBooks, string Name, Guid BookcaseId) { }
}