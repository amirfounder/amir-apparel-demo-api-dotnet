using System.ComponentModel.DataAnnotations;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Models
{
    public abstract class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
