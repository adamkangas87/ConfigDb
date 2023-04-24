using Domain.Common;
namespace Domain.Entities
{
    public class ServiceItem : Base<Guid>
    {
        public ServiceItem() { }
        public string Name { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<ConfigItem> ConfigItems { get; set; }
        public virtual ServiceLevel ServiceLevel { get; set; }
        public virtual ServiceType Type { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual Support Support { get; set; }
    }
}