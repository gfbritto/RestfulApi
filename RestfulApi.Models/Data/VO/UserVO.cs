using System;
using System.ComponentModel.DataAnnotations;

namespace RestfulApi.Models.Data.VO
{
    public class UserVO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string FullName { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
