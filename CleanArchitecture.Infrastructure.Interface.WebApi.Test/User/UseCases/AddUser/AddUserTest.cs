using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CleanArchitecture.Infrastructure.Interface.WebApi.Test.User.UseCases.AddUser
{
    public class AddUserTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public AddUserTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task AddUser()
        {
            // Arrange
            var client = factory.CreateClient();

            var data = new
            {
                Name = "test"
            };

            var json = JsonSerializer.Serialize(data);
            using var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/user/add", stringContent);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            //Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
