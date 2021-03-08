using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Domains
{
    public class Result : Entity
    {
        public int QuestionId { get; set; }
        
        public int RespondentId { get; set; }

        public int Value { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }

        [ForeignKey("RespondentId")]
        public virtual Respondent Respondent { get; set; }
    }
}
