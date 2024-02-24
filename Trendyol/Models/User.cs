using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Models
{
    public class User : IData
    {
        [Key]
        public int UserId {  get; set; }
        [Required, MaxLength(10), RegularExpression("^[A-Z][a-z]+$")]
        public string Name { get; set; }
        [Required, MaxLength(15), RegularExpression("^[A-Z][a-z]+$")]
        public string Surname { get; set; }
        [Required, MaxLength(255)]
        public string Login { get; set; }
        [Required, MaxLength(255), RegularExpression("@\"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$\"")]
        public string Email { get; set; }
        [Required, MaxLength(255), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{5,}$")]
        public string Password { get; set; }
        [Required, MaxLength(7), RegularExpression("/^\\d{6}-\\d{3}[0-9A-Za-z]$/\r\n")]
        public string FIN { get; set; }
        [Required, MaxLength(13), RegularExpression("^\\+\\d{9,13}$\r\n")]
        public string Phone { get; set; }
        [Required]
        public double Balance {  get; set; }
        public ICollection<Order> Orders {  get; set; }
    }

    
}
