using AutoMapper;
using BestPractices.Application.Requests;
using BestPractices.Application.Services;
using BestPractices.Domain.Exceptions;
using BestPractices.Domain.Repositories.UnitOfWork;
using BestPractices.Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using Moq;

namespace BestPractices.Tests.Service;

public class ClientServiceTests
{
    private readonly Mock<ILogger<ClientService>> mockLogger;
    private readonly Mock<IMapper> mockMapper;
    private readonly Mock<IUnitOfWork> mockUnitOfWork;
    private readonly ClientService clientService;

    public ClientServiceTests()
    {
        mockLogger = new Mock<ILogger<ClientService>>();
        mockMapper = new Mock<IMapper>();
        mockUnitOfWork = new Mock<IUnitOfWork>();

        clientService = new ClientService(
            mockUnitOfWork.Object,
            mockMapper.Object,
            mockLogger.Object
        );
    }

    [Fact]
    public async Task RegisterClient_ShouldReturnClientDTO_WhenCommitIsSuccessful()
    {
        // Arrange
        var clientRequest = new ClientRequest();
        var client = new Client();
        var clientId = Guid.NewGuid();

        mockMapper.Setup(m => m.Map<Client>(clientRequest)).Returns(client);
        mockUnitOfWork.Setup(u => u.Clients.RegisterClient(client)).ReturnsAsync(clientId);
        mockUnitOfWork.Setup(u => u.Commit()).ReturnsAsync(true);

        // Act
        var result = await clientService.RegisterClient(clientRequest);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(clientId, result.Id);
    }

    [Fact]
    public async Task RegisterClient_ShouldThrowNotCommitedException_WhenCommitFails()
    {
        // Arrange
        var clientRequest = new ClientRequest();
        var client = new Client();

        mockMapper.Setup(m => m.Map<Client>(clientRequest)).Returns(client);
        mockUnitOfWork.Setup(u => u.Clients.RegisterClient(client)).ReturnsAsync(It.IsAny<Guid>());
        mockUnitOfWork.Setup(u => u.Commit()).ReturnsAsync(false);

        // Act & Assert
        await Assert.ThrowsAsync<NotCommitedException>(() => clientService.RegisterClient(clientRequest));
    }
}