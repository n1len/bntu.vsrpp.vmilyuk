using System;
using System.Collections.Generic;
using System.Text;

namespace bntu.vsrpp.vmilyuk.Core.Models
{
    public class Currency
    {
        public int Cur_ID { get; set; }
        public int Cur_Code { get; set; }
        public DateTime Date { get; set; }
        public string Cur_Abbreviation { get; set; }
        public int Cur_Scale { get; set; }
        public string Cur_Name { get; set; }
        public float Cur_OfficialRate { get; set; }
    }
}
