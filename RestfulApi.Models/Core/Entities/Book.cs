using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulApi.Models.Core.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Author { get; set; }

        public DateTime LaunchDate { get; set; }

        public int NumberOfPages { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
    }
}
