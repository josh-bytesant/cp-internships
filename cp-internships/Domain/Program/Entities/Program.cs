
namespace Domain.Program.Entities
{
    public class Program
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public List<Question> PersonalInformation { get; set; }
        public List<Question> AdditionalQuestions { get; set; }


        #region CreateProgramObjectHelper
        public static Program Create()
        {
            string programId = Guid.NewGuid().ToString();
            MultiChoiceType multiChoice(List<string> choices, bool addOtherText, int maxChoiceAllowed) => new MultiChoiceType {
                Name = "Multichoice", Choice = choices, AddOtherText = addOtherText, MaxChoiceAllowed = maxChoiceAllowed };

            DropDownType dropDown(List<string> choices, bool addOtherText) => new DropDownType
            {
                Name = "Dropdown",
                Choice = choices,
                AddOtherText = addOtherText
            };


            List<Question> personalQuestions = new List<Question>
            {
                new Question { Id = Guid.NewGuid().ToString(), Mandatory = true, Hiden = false, Internal = false, Type = new QuestionType {Name = "Text"}, Text = "First Name" },
                new Question { Id = Guid.NewGuid().ToString(), Mandatory = true, Hiden = false, Internal = false, Type = new QuestionType {Name = "Text"}, Text = "Last Name" },
                new Question { Id = Guid.NewGuid().ToString(), Mandatory = true, Hiden = false, Internal = false, Type = new QuestionType {Name = "Text"}, Text = "Email" },
                new Question { Id = Guid.NewGuid().ToString(), Mandatory = false, Hiden = true, Internal = false, Type = new QuestionType { Name = "Text" }, Text = "Phone (without dial code)" },
                new Question { Id = Guid.NewGuid().ToString(), Mandatory = false, Hiden = true, Internal = false, Type = new QuestionType { Name = "Text" }, Text = "Nationality" },
                new Question { Id = Guid.NewGuid().ToString(), Mandatory = false, Hiden = true, Internal = false, Type = new QuestionType { Name = "Text" }, Text = "Current Residence" },
                new Question { Id = Guid.NewGuid().ToString(), Mandatory = false, Hiden = true, Internal = false, Type = new QuestionType { Name = "Number" }, Text = "ID Number" },
                new Question { Id = Guid.NewGuid().ToString(), Mandatory = false, Hiden = true, Internal = false, Type = new QuestionType { Name = "Date" }, Text = "Date of Birth" },
                new Question { Id = Guid.NewGuid().ToString(), Mandatory = false, Hiden = true, Internal = false, Type = dropDown( choices: new List<string> { "Male", "Female"}, addOtherText: false), Text = "Gender"}
            };


            List<Question> addtionalQuestions = new List<Question>
            {
                new Question { Id = Guid.NewGuid().ToString(), Mandatory = false, Hiden = false, Internal = false, Type = new QuestionType { Name = "Paragraph" }, Text = "Please tell me about yourself in less than 500 words" },
                new Question { Id = Guid.NewGuid().ToString(), Mandatory = false, Hiden = false, Internal = false, Type = dropDown( choices: new List<string> { "2023", "2022", "2021", "2020" },
                             addOtherText: false), Text = "Please select your year of graduation from the list below"},
                new Question { Id = Guid.NewGuid().ToString(), Mandatory = false, Hiden = false, Internal = false, Type = new QuestionType{Name = "Yes/No" }, Text = "Have you ever been rejected by thew UK embassy?" },
                new Question { Id = Guid.NewGuid().ToString(), Mandatory = false, Hiden = false, Internal = false, Type = multiChoice( choices: new List<string> { "Web Development", "Data Analysis", "Database Administration", "Server Administration" },
                              addOtherText: false, maxChoiceAllowed: 5), Text = "Please select at least 3 answers from the dropdowns below."},
                new Question { Id = Guid.NewGuid().ToString(), Mandatory = false, Hiden = false, Internal = false, Type = new QuestionType{Name = "Number" }, Text = "How many years of experience do you have, please enter the number below" },
                 new Question { Id = Guid.NewGuid().ToString(), Mandatory = false, Hiden = false, Internal = false, Type = new QuestionType{Name = "Date" }, Text = "Please provide the date that you have moved to the UK" }
            };

            return new Program
            {
                id = programId,
                Title = "Summer Internship 24",
                Description = "Summer internship program for new graduates into exiciting companies in Banking, Tech, Medicine and Auditing",
                DateModified = DateTime.UtcNow,
                DateCreated = DateTime.UtcNow,
                PersonalInformation = personalQuestions,
                AdditionalQuestions = addtionalQuestions
            };
        }
        #endregion
    }
}
