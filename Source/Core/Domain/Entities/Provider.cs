using Domain.Common;
namespace Domain.Entities
{
    public class Provider : Base<Guid>
    {

        public Provider() 
        {
        
        }
        public string Name { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<ConfigType> Types { get; set; }
        public virtual ICollection<ServiceItem> Items { get; set; }
    }
}