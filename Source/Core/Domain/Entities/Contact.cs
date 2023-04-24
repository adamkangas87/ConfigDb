using Domain.Common;
namespace Domain.Entities
{
    public class Contact : Base<Guid>
    {
        public Contact() 
        { 
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public virtual Provider Provider { get; set; }
        public Guid ProviderId { get; set; }
    }
}