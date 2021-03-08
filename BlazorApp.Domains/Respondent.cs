using System.Collections.Generic;

namespace BlazorApp.Domains
{
    public class Respondent : Entity
    {
        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}
