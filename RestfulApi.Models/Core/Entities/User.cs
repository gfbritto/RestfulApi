using System;
using System.ComponentModel.DataAnnotations;

namespace RestfulApi.Models.Core.Entities
{
    public class User: BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(130)]
        public string Password { get; set; }

        [Required]
        [StringLength(120)]
        public string FullName { get; set; }

        [StringLength(500)]
        public string RefreshToken { get; set; }

        [Required]
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
