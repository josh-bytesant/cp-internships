using NSubstitute;
using Domain.Shared;
using FluentAssertions;
using Domain.Program.Shared;
using Domain.Program.Create;
using Domain.Program.Update;

namespace Application.Test.Program
{
    public class CreateAndUpdateProgramUnitTests
    {
        private static Domain.Program.Entities.Program? reuseAbleProgramObject = null;
        private readonly CreateProgramService _createProgramService;
        private readonly UpdateProgramService _updateProgramService;
        public CreateAndUpdateProgramUnitTests()
        {
            IUpsertProgramRepository _UpsertProgramRepositoryMock = Substitute.For<IUpsertProgramRepository>();
            _createProgramService = new CreateProgramService(_UpsertProgramRepositoryMock);
            _updateProgramService = new UpdateProgramService(_UpsertProgramRepositoryMock);
        }

        [Fact]
        public async Task CreateProgram_Should_ReturnSuccess_WhenProgramCreated()
        {
            //Arrange
            var program = Domain.Program.Entities.Program.Create();
            reuseAbleProgramObject = program;
            //Act
            Result result = await _createProgramService.Create(program, default);

            //Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task UpdateProgram_Should_ReturnSuccess_WhenProgramUpdated()
        {
            //Arrange
            if(reuseAbleProgramObject == null) reuseAbleProgramObject = Domain.Program.Entities.Program.Create();
            reuseAbleProgramObject.DateModified = DateTime.UtcNow;
            //Act
            Result result = await _updateProgramService.Update(reuseAbleProgramObject, default);

            //Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}
