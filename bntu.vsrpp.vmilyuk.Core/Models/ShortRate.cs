using System;
using System.ComponentModel.DataAnnotations;

namespace bntu.vsrpp.vmilyuk.Core.Models
{
    public class ShortRate
    {
        public int Cur_ID { get; set; }
        [Key]
        public DateTime Date { get; set; }
        public decimal? Cur_OfficialRate { get; set; }
    }
}
