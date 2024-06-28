using BestPractices.API.Controllers;
using BestPractices.Application.DTOs;
using BestPractices.Application.Interfaces;
using BestPractices.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;
using System.Net;

namespace ClientControllerTests;

public class ControllerTests
{
    private readonly Mock<IClientService> mockClientService;
    private readonly Mock<ILogger<ClientController>> mockControllerLogger;
    private readonly ClientController mockClientController;

    public ControllerTests()
    {
        mockClientService = new Mock<IClientService>();
        mockControllerLogger = new Mock<ILogger<ClientController>>();
        mockClientController = new ClientController(mockClientService.Object, mockControllerLogger.Object);
    }

    [Fact]
    public async Task RegisterClient_ValidData_ReturnsOk()
    {
        // Arrange
        var clientRequest = new ClientRequest
        {
            Name = "John Doe",
            Email = "john.doe@example.com",
            PhoneNumber = 123456789
        };

        var clientCreated = new ClientDTO {Id = Guid.NewGuid() };
        mockClientService.Setup(x => x.RegisterClient(It.IsAny<ClientRequest>())).ReturnsAsync(clientCreated);

        // Act
        var result = await mockClientController.RegisterClient(clientRequest) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task RegisterClient_InvalidData_ReturnsBadRequest()
    {
        // Arrange
        var clientRequest = new ClientRequest
        {
            Name = null,
            Email = "john.doe@example.com",
            PhoneNumber = 213123123
        };

        // Act
        var result = await mockClientController.RegisterClient(clientRequest) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
    }
}