using Registracija.Models;
using System.Collections.Generic;

namespace Registracija.Dtos
{
    public class RegistrationDto
    {
        public int QuestionId { get; set; }
        public string QuestionValue { get; set; }
        public int AnswerId { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
