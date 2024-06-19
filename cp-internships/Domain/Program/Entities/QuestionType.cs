
namespace Domain.Program.Entities
{
    public class QuestionType
    {
        public string Name { get; set; }

        public static List<string> GetQuestionTypes => new List<string> { "Text", "Paragraph", "YesNo", "Dropdown", "Date", "Number", "MultiChoice" };
    }

     

    public class MultiChoiceType : QuestionType
    {
        public List<string> Choice { get; set; }
        public bool AddOtherText { get; set; }
        public int MaxChoiceAllowed { get; set; }
    }

    public class DropDownType : QuestionType
    {
        public List<string> Choice { get; set; }
        public bool AddOtherText { get; set; }
    }
}
