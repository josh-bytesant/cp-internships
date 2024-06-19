
using Domain.Application.Create;
using Domain.Program.Create;
using Domain.Program.Shared;
using Domain.Program.Update;
using Domain.Shared;
using FluentAssertions;
using NSubstitute;

namespace Application.Test.Application
{
    public class CreateApplicationUnitTests
    {
        private readonly CreateApplicationService _createApplicationService;
        public CreateApplicationUnitTests()
        {
            ICreateApplicationRepository _createApplicationRepositoryMock = Substitute.For<ICreateApplicationRepository>();
            _createApplicationService = new CreateApplicationService(_createApplicationRepositoryMock);
        }

        [Fact]
        public async Task CreateApplication_Should_ReturnError_WhenProgramNotFound()
        {
            //Arrange
            var application = new Domain.Application.Entities.Application();

            //Act
            Result result = await _createApplicationService.Create(application, default);

            //Assert
            result.Error.Should().Be(CreateApplicationErrors.ProgramNotFoundForApplication);
        }

        [Fact]
        public async Task CreateApplication_Should_ReturnSuccess_WhenApplicationCreated()
        {
            //Arrange
            var application = new Domain.Application.Entities.Application();

            //Act
            Result result = await _createApplicationService.Create(application, default);

            //Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}
