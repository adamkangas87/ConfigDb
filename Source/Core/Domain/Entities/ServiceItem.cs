using Domain.Common;
namespace Domain.Entities
{
    public class ServiceItem : Base<Guid>
    {
        public ServiceItem() 
        { 
        }
        public string Name { get; set; }
        public virtual Provider Provider { get; set; }
        public Guid ProviderId { get; set; }
        public virtual Location Location { get; set; }
        public Guid LocationId { get; set; }
       
        public virtual ServiceLevel ServiceLevel { get; set; }
        public Guid ServiceLevelId { get; set; }
        public virtual ServiceType Type { get; set; }
        public Guid TypeId { get; set; }



        public virtual ICollection<ConfigItem> ConfigItems { get; set; }
    }
}