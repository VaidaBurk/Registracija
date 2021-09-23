namespace Registracija.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public Question Question { get; set; }
    }
}
