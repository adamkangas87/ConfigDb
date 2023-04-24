
using Domain.Interfaces;

namespace Domain.Common
{
    public abstract class Base<TId> : Auditable, IBase<TId>
    {
        public TId Id { get; set; }
    }
}

