using Domain.Common;
namespace Domain.Entities
{
    public class Skill : Base<Guid>
    {
        public Skill() { }
        public string Tech { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public Provider Provider { get; set; }


    }
}