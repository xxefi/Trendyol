using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TrackingId { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey("User")]
        public int UserId {  get; set; }
        public User Users { get; set; }
        [ForeignKey("Products")]
        public string Product { get; set; }
        public int ProductsCount { get; set; }
        public string Status { get; set; } = "Заказ сделан";
        public DateTime Created { get; set; }   
    }
}
