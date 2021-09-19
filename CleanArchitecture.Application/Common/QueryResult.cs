using System;

namespace CleanArchitecture.Application.Common
{
    public class QueryResult<Tdata, Terrorcode>
        where Tdata : class
        where Terrorcode : Enum
    {
        public static QueryResult<Tdata, Terrorcode> CreateOk(Tdata data)
        {
            return new QueryResult<Tdata, Terrorcode> { Data = data };
        }

        public static QueryResult<Tdata, Terrorcode> CreateError(Error<Terrorcode> error)
        {
            return new QueryResult<Tdata, Terrorcode> { Error = error };
        }

        public bool Success { get { return Error == null; } }
        public Tdata Data { get; init; }
        public Error<Terrorcode> Error { get; init; }
    }
}
