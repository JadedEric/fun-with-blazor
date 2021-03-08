namespace BlazorApp.Domains
{
    public class Question : Entity
    {
        public string Name { get; set; }

        public virtual Objective Objective { get; set; }
    }
}
