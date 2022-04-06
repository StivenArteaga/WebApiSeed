using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Employee : Entidad<int>
    {
        [Required]
        [StringLength(50)]
        public string NetworkUSer { get; set; }
        [Required]
        [StringLength(50)]
        public string Badge { get; set; }
        [Required]
        [StringLength(50)]
        public string Division { get; set; }
        [Required]
        [StringLength(50)]
        public string Deparment { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool SystemAccess { get; set; }
    }
}
