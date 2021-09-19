using System;
using MediatR;

namespace CleanArchitecture.Application.Common
{
    public interface IQuery<Tdata, Terrorcode> : IRequest<QueryResult<Tdata, Terrorcode>>
        where Tdata : class
        where Terrorcode : Enum
    {
    }
}
