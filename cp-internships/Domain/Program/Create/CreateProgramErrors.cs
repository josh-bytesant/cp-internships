using Domain.Shared;

namespace Domain.Program.Create
{
    public static class CreateProgramErrors
    {
        public static readonly Error ErrorCreatingProgram = new(
        "CreateProgram.ErrorCreatingProgram",
        "An error was encountered when creating the program");
    }
}
