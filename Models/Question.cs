using System.Collections.Generic;

namespace Registracija.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
