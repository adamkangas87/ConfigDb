using Domain.Common;
namespace Domain.Entities
{
    public class Location : Base<Guid>
    {
        public Location() 
        { 
        }
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public virtual Provider Provider { get; set; }
        public Guid ProviderId { get; set; }

        public virtual ServiceItem ServiceItem { get; set; }
        public Guid ServiceItemId { get; set; }

    }
}