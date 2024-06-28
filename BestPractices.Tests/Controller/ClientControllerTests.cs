using BestPractices.API.Controllers;
using BestPractices.Application.Interfaces;
using BestPractices.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Xunit.Categories;

namespace BestPractices.Tests.Controller
{
    [UnitTest]
    public class ClientControllerTests
    {
        private readonly Mock<IClientService> mockClientService;
        private readonly Mock<ILogger<ClientController>> mockControllerLogger;
        private readonly ClientController mockClientController;

        public ClientControllerTests()
        {
            mockClientService = new Mock<IClientService>();
            mockControllerLogger = new Mock<ILogger<ClientController>>();
            mockClientController = new ClientController(mockClientService.Object, mockControllerLogger.Object);
        }

        //[Fact]
        //public async Task RegisterClient_ValidRequest_ReturnsOk()
        //{
        //    // Arrange
        //    var clientRequest = new ClientRequest
        //    {
        //        Name = "John Doe",
        //        Email = "john.doe@example.com",
        //        PhoneNumber = 123456789
        //    };
        //    mockClientService.Setup(service => service.RegisterClient(clientRequest)).ReturnsAsync(true);

        //    // Act
        //    var result = await mockClientController.RegisterClient(clientRequest) as OkObjectResult;

        //    // Assert
        //    Assert.Equal(200, result.StatusCode);
        //}

        [Fact]
        public async Task RegisterClient_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var clientRequest = new ClientRequest
            {
                Name = "John Doe",
                // Missing Email and PhoneNumber
            };

            // Act
            var result = await mockClientController.RegisterClient(clientRequest) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Informe todos os dados do registro do cliente", result.Value);
        }
    }
}