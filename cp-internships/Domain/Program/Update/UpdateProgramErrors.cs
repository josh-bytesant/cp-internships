using Domain.Shared;

namespace Domain.Program.Update
{
    public static class UpdateProgramErrors
    {
        public static readonly Error ErrorUpdatingProgram = new(
        "UpdateProgram.ErrorUpdatingProgram",
        "An error was encountered when updating the program");
    }
}
