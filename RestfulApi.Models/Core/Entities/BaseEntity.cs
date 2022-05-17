using System.ComponentModel.DataAnnotations;

namespace RestfulApi.Models.Core.Entities
{
    public abstract class BaseEntity
    {
        [Required]
      public long Id { get; set; }
    }
}
