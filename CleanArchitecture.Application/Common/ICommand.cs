using System;
using MediatR;

namespace CleanArchitecture.Application.Common
{
    public interface ICommand<Tdata, Terrorcode> : IRequest<CommandResult<Tdata, Terrorcode>> 
        where Tdata : class
        where Terrorcode : Enum
    {
        public void Validate();
    }
}
