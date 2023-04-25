
namespace Application.Features.Contact.Models
{
    public class CreateContactModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public Guid ProviderId { get; set; }
    }


}
