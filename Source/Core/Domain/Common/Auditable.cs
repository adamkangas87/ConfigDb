namespace Domain.Common
{
    public class Auditable
    {
        public DateTimeOffset? DateCreated { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTimeOffset? DateModified { get; set; }
        public Guid ModifiedBy { get; set; }

        public byte[] RowVersion { get; set; }

    }
}
