using System;
using System.ComponentModel.DataAnnotations;

namespace amir_apparel_demo_api_dotnet_5.Data.Models
{
    public class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
