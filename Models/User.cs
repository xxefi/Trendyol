using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Models
{
    public class User
    {
        [Key]
        public int UserId {  get; set; }
        [Required, MaxLength(10)]
        public string Name { get; set; }
        [Required, MaxLength(15)]
        public string Surname { get; set; }
        [Required, MaxLength(255)]
        public string Login { get; set; }
        [Required, MaxLength(255)]
        public string Email { get; set; }
        [Required, MaxLength(255)]
        public string Password { get; set; }
        [Required, MaxLength(7)]
        public string FIN { get; set; }
        [Required, MaxLength(13)]
        public string Phone { get; set; }
        [Required]
        public decimal Balance {  get; set; }
        public ICollection<Order> Orders { get; set; }
    }

    
}
