using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common;

namespace CleanArchitecture.Application.User.UseCases.AddUser
{
    public class AddUserUseCase
    {
        public class Command : ICommand<ResultData, Errors>
        { 
            /// <summary>
            /// Name of the user that initiated the command
            /// </summary>
            public string User { get; init; }

            /// <summary>
            /// Name of the user that should be created
            /// </summary>
            public string Name { get; init; }

            public void Validate()
            {
                if (string.IsNullOrWhiteSpace(User))
                {
                    throw new ArgumentException("User can not be empty");
                }

                if (string.IsNullOrWhiteSpace(Name))
                {
                    throw new ArgumentException("Name can not be empty");
                }
            }
        }

        public class ResultData
        {
            /// <summary>
            /// ID of the created user
            /// </summary>
            public Guid Id { get; init; }
        }

        public enum Errors
        {
            Validation,
            Domain,
            Persistance
        }

        public class Handler : CommandHandler<Command, ResultData, Errors>
        {
            private readonly IRepository repository;

            public Handler(IRepository repository)
            {
                this.repository = repository;
            }

            // Catch all exceptions, we dont want the outer layers to need to catch "random" exceptions
            // instead we should return well defined and typesafe errors
            protected override async Task<CommandResult<ResultData, Errors>> HandleCommandAsync(Command command, CancellationToken cancellationToken)
            {
                try
                {
                    command.Validate();
                }
                catch (Exception ex)
                {
                    return CreateErrorResult(Errors.Validation, ex.Message);
                }

                Domain.User user;
                try
                {
                    user = Domain.User.Create(command.Name);
                }
                catch (Exception ex)
                {
                    return CreateErrorResult(Errors.Domain, ex.Message);
                }

                try
                {
                    await repository.CreateUserAsync(user.Id, user.Name);
                }
                catch (Exception ex)
                {
                    return CreateErrorResult(Errors.Persistance, ex.Message);
                }

                return CreateOkResult(new ResultData { Id = user.Id });
            }

            private CommandResult<ResultData, Errors> CreateOkResult(ResultData result)
            {
                return CommandResult<ResultData, Errors>.CreateOk(result);
            }

            private CommandResult<ResultData, Errors> CreateErrorResult(Errors error, string description)
            {
                return CommandResult<ResultData, Errors>.CreateError(Error<Errors>.Create(error, description));
            }
        }

        public interface IRepository
        {
            Task CreateUserAsync(Guid id, string name);
        }
    }
}
