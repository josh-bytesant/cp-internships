using Domain.Program.Entities;

namespace Domain.Program.Get
{
    public  class GetProgramDTO
    {
        public string id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> QuestionTypes { get; set; }
        public List<Question> PersonalInformation { get; set; }
        public List<Question> AdditionalQuestions { get; set; }
    }
}
