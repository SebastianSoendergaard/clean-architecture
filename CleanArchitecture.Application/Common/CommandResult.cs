using System;

namespace CleanArchitecture.Application.Common
{
    public class CommandResult<Tdata, Terrorcode> 
        where Tdata : class 
        where Terrorcode : Enum
    {
        public static CommandResult<Tdata, Terrorcode> CreateOk(Tdata data)
        {
            return new CommandResult<Tdata, Terrorcode> { Data = data };
        }

        public static CommandResult<Tdata, Terrorcode> CreateError(Error<Terrorcode> error)
        {
            return new CommandResult<Tdata, Terrorcode> { Error = error };
        }

        public bool Success { get { return Error == null; } }
        public Tdata Data { get; init; }
        public Error<Terrorcode> Error { get; init; }
    }
}
