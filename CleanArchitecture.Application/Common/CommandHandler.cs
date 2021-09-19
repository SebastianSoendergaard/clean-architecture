using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitecture.Application.Common
{
    public abstract class CommandHandler<Tcommand, Tdata, Terrorcode> : IRequestHandler<Tcommand, CommandResult<Tdata, Terrorcode>>
        where Tcommand : ICommand<Tdata, Terrorcode>
        where Tdata : class
        where Terrorcode : Enum
    {
        public Task<CommandResult<Tdata, Terrorcode>> Handle(Tcommand request, CancellationToken cancellationToken)
        {
            return HandleCommandAsync(request, cancellationToken);
        }

        protected abstract Task<CommandResult<Tdata, Terrorcode>> HandleCommandAsync(Tcommand command, CancellationToken cancellationToken);
    }
}
