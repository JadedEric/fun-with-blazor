using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Domains
{
    public class Objective : Entity
    {
        public int QuestionId { get; set; }

        public int Value { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
