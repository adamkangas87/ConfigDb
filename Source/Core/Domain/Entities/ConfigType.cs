
using Domain.Common;
namespace Domain.Entities
{
    public class ConfigType : Base<Guid>
    {
        public ConfigType() { }
        public string Name { get; set; }
        public virtual Provider Provider { get; set; }
        public Guid ProviderId { get; set; }


        //Navigation Property
        public virtual ICollection<ConfigItem> ConfigItems { get; set; }
    }
}