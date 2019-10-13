using System;

namespace Tti.Estate.Data.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
        }

        public long Id { get; set; }
        public string usuario { get; set; }
        public DateTime? fecCreacion { get; set; }
        public DateTime? fecModificacion { get; set; }
    }
}
