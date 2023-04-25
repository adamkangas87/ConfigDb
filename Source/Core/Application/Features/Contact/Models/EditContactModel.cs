
namespace Application.Features.Contact.Models
{
    public class EditContactModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public Guid ProviderId { get; set; }
    }


}
