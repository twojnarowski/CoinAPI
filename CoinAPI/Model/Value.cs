using System;
using System.ComponentModel.DataAnnotations;

namespace CoinAPI.Model
{
    public class Value
    {
        [Key]
        public string ValueID { get; set; }

        public string CurrencyID { get; set; }
        public DateTime? Timestamp { get; set; }
        public decimal Rate { get; set; }
    }
}