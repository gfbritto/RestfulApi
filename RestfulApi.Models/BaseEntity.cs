using System.ComponentModel.DataAnnotations;

namespace RestfulApi.Models
{
    public abstract class BaseEntity
    {
        [Required]
        public long Id { get; set; }
    }
}
