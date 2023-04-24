using Domain.Common;

namespace Domain.Entities
{
    public class ConfigItem : Base<Guid>
    {
        public ConfigItem() 
        { 
        
        }
        public string Name { get; set; }
        public virtual ConfigType Type { get; set; }
        public Guid TypeId { get; set; }
    }
}