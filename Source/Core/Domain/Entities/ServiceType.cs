using Domain.Common;
namespace Domain.Entities
{
    public class ServiceType : Base<Guid>
    {
        public ServiceType() 
        { 
        }
        public string Name { get; set; }

        public virtual ICollection<ServiceItem> Items { get; set; }
    }
}