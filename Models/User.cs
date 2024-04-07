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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FIN { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public decimal Balance {  get; set; }
        public ICollection<Order> Orders { get; set; }
    }

    
}
