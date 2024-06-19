using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Create
{
    public class CreateApplicationAnswerDTO
    {
        public string QuestionId { get; set; }
        public string ProgramId { get; set; }
        public string QuestionText { get; set; }
        public dynamic Value { get; set; }
    }
}
