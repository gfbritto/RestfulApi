using System.ComponentModel.DataAnnotations;

namespace RestfulApi.Models
{
    public class Person : BaseEntity
    {
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(500)]
        public string Adress { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }
    }
}
