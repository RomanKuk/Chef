using System;

namespace Chef.DAL.Entities.Common
{
    public abstract class AuditEntity : Entity
    {
        public DateTime CreatedAt { get; set; }
    }
}
