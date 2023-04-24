using Domain.Common;
namespace Domain.Entities
{
    public class ServiceLevel : Base<Guid>
    {
        public ServiceLevel() { }
        public string Name { get; set; }
        public double Duration { get; set; }
    }
}