using BestPractices.Domain.ValueObjects;
using BestPractices.Infraestructure.Data.DbContextConfig;
using BestPractices.Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace BestPractices.Tests.Repository;

public class ClientRepositoryTests
{
    private readonly ApplicationDbContext _context;
    private readonly Mock<ILogger<ClientRepository>> _mockLogger;
    private readonly ClientRepository _clientRepository;

    public ClientRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _context = new ApplicationDbContext(options);
        _mockLogger = new Mock<ILogger<ClientRepository>>();
        _clientRepository = new ClientRepository(_context, _mockLogger.Object);
    }

    [Fact]
    public async Task RegisterClient_ShouldReturnGuid_WhenClientIsRegistered()
    {
        // Arrange
        var client = new Client
        {
            // Preencha as propriedades do cliente conforme necessário
            // Por exemplo: Id = Guid.NewGuid(), Name = "Test Client", etc.
        };

        // Act
        var result = await _clientRepository.RegisterClient(client);

        // Assert
        Assert.IsType<Guid>(result);
        Assert.NotEqual(Guid.Empty, result);
    }

    [Fact]
    public async Task RegisterClient_ShouldLogInformation_WhenCalled()
    {
        // Arrange
        var client = new Client
        {
            // Preencha as propriedades do cliente conforme necessário
        };

        // Act
        await _clientRepository.RegisterClient(client);

        // Assert
        _mockLogger.Verify(
            logger => logger.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Registering customer...")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }
}