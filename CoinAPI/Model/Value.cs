using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoinAPI.Model
{
    public class Value
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime? Timestamp { get; set; }
        public decimal Rate { get; set; }
    }
}
