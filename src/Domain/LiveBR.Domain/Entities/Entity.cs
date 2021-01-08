using System;

namespace LiveBR.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
        
        
    }
}