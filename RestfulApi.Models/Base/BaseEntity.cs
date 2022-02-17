using System.ComponentModel.DataAnnotations;

namespace RestfulApi.Models.Base
{
    public abstract class BaseEntity
    {
        [Required]
        public long Id { get; set; }
    }
}
