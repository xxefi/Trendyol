using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Models
{
    public class WareHouse
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Products")]
        public int ProductId {  get; set; }
        [Required, MaxLength(30), RegularExpression("^[A-Z][a-z]+$")]
        public string Name { get; set; }
        public int ProductCount {  get; set; }
        
    }
}
