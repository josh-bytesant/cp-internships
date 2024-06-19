using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Entities
{
    public class Answer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string QuestionId { get; set; }
        public string ProgramId { get; set; }
        public string QuestionText { get; set; }
        public dynamic Value { get; set; }
    }
}
