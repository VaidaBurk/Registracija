namespace Registracija.Models
{
    public class Registration
    {
        public int? RegId { get; set; }
        public int QuestionId { get; set; }

        public Question Question { get; set; }
        public int AnswerId { get; set; }

        public Answer Answer { get; set; }

    }
}
