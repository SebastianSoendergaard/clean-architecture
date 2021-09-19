using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common
{
    public interface IMediator
    {
        Task<CommandResult<Tdata, Terrorcode>> SendCommandAsync<Tdata, Terrorcode>(ICommand<Tdata, Terrorcode> command) where Tdata : class where Terrorcode : Enum;
        Task<QueryResult<Tdata, Terrorcode>> SendQueryAsync<Tdata, Terrorcode>(IQuery<Tdata, Terrorcode> query) where Tdata : class where Terrorcode : Enum;
    }

    public class Mediator : IMediator
    {
        private readonly MediatR.IMediator mediatr;

        public Mediator(MediatR.IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        Task<CommandResult<Tdata, Terrorcode>> IMediator.SendCommandAsync<Tdata, Terrorcode>(ICommand<Tdata, Terrorcode> command)
        {
            return mediatr.Send(command);
        }

        Task<QueryResult<Tdata, Terrorcode>> IMediator.SendQueryAsync<Tdata, Terrorcode>(IQuery<Tdata, Terrorcode> query)
        {
            return mediatr.Send(query);
        }
    }
}
