using Domain.Common;

namespace Domain.Entities
{
    public class ConfigItem : Base<Guid>
    {
        public ConfigItem() { }
        public string Name { get; set; }
        public virtual ConfigType ConfigType { get; set; }
        public Guid ConfigTypeId { get; set; }
    }
}