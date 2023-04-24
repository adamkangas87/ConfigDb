using Domain.Common;

namespace Domain.Entities
{
    public class Support:Base<Guid>
    {
        public Support() { }
        public string Portal { get; set; }
    }
}