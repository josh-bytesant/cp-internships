using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Entities
{
    public class Application
    {
        public string id { get; set; } 
        public string ProgramId { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; } 
        public List<Answer> personalInformation { get; set; }
        public List<Answer> additionalQuestions { get; set; }
    }
}
