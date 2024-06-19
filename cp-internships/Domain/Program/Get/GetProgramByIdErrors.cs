using Domain.Shared;

namespace Domain.Program.Get
{
    public static class GetProgramByIdErrors
    {
        public static readonly Error NoId = new("GetProgramById.NoId", "No Id provided for the request");

        public static Error NotFound(string Id) => new(
        "GetProgramById.NotFound", $"The program with the Id = '{Id}' was not found");
    }
}
