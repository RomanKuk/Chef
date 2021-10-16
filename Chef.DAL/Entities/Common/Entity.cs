using System;

namespace Chef.DAL.Entities.Common
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
