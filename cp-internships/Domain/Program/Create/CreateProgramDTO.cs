using Domain.Program.Entities;

namespace Domain.Program.Create
{
    public class CreateProgramDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Question> PersonalInformation { get; set; }
        public List<Question> AdditionalQuestions { get; set; }

    }

}
