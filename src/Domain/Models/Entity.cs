using System;

namespace Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public bool Removed { get; private set; }
        public DateTime CretedAt { get; private set; }
        public DateTime? LastModifyAt { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            Removed = false;
            CretedAt = DateTime.UtcNow;
        }

        public void GenerateChange()
        {
            LastModifyAt = DateTime.UtcNow;
        }

        public void Remove ()
        {
            Removed = true;
            GenerateChange();
        }
    }
}
