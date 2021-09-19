using System.Threading.Tasks;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.User.UseCases.AddUser;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Infrastructure.Interface.WebApi.User.UseCases.AddUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddUser([FromBody] AddUserDto dto)
        {
            // Here we need extra information so we do some mapping to the command, 
            // if not we could have choosen to just the endpoint take the command as argument
            var command = new AddUserUseCase.Command
            {
                User = "test", // TODO: get from httpcontext
                Name = dto.Name
            };

            var result = await mediator.SendCommandAsync(command);

            // Here we analyse the result before returning reply to forntend
            // we could also just return the entire result and let frontend handle it
            if (!result.Success)
            {
                switch (result.Error.Code)
                {
                    case AddUserUseCase.Errors.Validation:
                        return StatusCode(400, new { Error = result.Error.Description });

                    case AddUserUseCase.Errors.Domain:
                        return StatusCode(409, new { Error = result.Error.Description });

                    case AddUserUseCase.Errors.Persistance:
                        return StatusCode(500, new { Error = result.Error.Description });
                }
            }

            return StatusCode(200, result.Data);
        }

        public class AddUserDto
        { 
            public string Name { get; set; }
        }
    }
}
