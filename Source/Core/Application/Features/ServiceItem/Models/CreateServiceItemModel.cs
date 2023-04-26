
namespace Application.Features.ServiceItem.Models
{
    public class CreateServiceItemModel
    {
        public string Name { get; set; }
        public Guid ProviderId { get; set; }
        public Guid LocationId { get; set; }
        public Guid ServiceLevelId { get; set; }
        public Guid TypeId { get; set; }

    }


}
