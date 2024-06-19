using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Create
{
    public class CreateApplicationDTO
    {
        public string ProgramId { get; set; }
        public List<CreateApplicationAnswerDTO> personalInformation { get; set; }
        public List<CreateApplicationAnswerDTO> additionalQuestions { get; set; }
    }
}
