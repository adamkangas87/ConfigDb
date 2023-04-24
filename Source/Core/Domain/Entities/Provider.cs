using Domain.Common;
namespace Domain.Entities
{
    public class Provider : Base<Guid>
    {

        public Provider() 
        {
        
        }
        public string Name { get; set; }
        public virtual Location Location { get; set; }
        public Guid LocationId { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<ConfigType> Types { get; set; }
        public virtual ICollection<ServiceItem> Items { get; set; }
    }
}