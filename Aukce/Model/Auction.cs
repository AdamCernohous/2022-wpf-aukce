using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aukce.Model
{
    public class Auction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        public User LastBuyer { get; set; }
        public User Author { get; set; }
    }
}
