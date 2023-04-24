
using Domain.Common;
namespace Domain.Entities
{
    public class ConfigType : Base<Guid>
    {
        public ConfigType() 
        { 
        
        }
        public string Name { get; set; }
        public virtual Provider Provider { get; set; }
        public Guid ProviderId { get; set; }
        public virtual ICollection<ConfigItem> Items { get; set; }
    }
}