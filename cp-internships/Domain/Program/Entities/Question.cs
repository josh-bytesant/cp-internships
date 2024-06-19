
namespace Domain.Program.Entities
{
    public class Question
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public dynamic Type { get; set; }
        public string Text { get; set; }
        public bool Mandatory { get; set; }
        public bool Hiden { get; set; }
        public bool Internal { get; set; }


    }
}
