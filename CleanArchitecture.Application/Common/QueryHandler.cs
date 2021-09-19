using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitecture.Application.Common
{
    public abstract class QueryHandler<Tquery, Tdata, Terrorcode> : IRequestHandler<Tquery, QueryResult<Tdata, Terrorcode>>
    where Tquery : IQuery<Tdata, Terrorcode>
    where Tdata : class
    where Terrorcode : Enum
    {
        public Task<QueryResult<Tdata, Terrorcode>> Handle(Tquery request, CancellationToken cancellationToken)
        {
            return HandleCommandAsync(request, cancellationToken);
        }

        protected abstract Task<QueryResult<Tdata, Terrorcode>> HandleCommandAsync(Tquery command, CancellationToken cancellationToken);
    }
}
