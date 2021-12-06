using System;
using System.ComponentModel.DataAnnotations;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Models
{
    public abstract class Entity : IEntity
    {
        public Entity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
