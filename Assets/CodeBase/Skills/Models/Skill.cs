namespace CodeBase.Skills.Models
{
    public class Skill : ISkill
    {
        public string Id { get; set; }
        
        public Skill (string id) => 
            Id = id;
    }
}
