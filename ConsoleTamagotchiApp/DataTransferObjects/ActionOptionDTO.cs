using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTamagotchiApp.DataTransferObjects
{
   public class ActionOptionDTO
    {
        public int OptionId { get; set; }
        public string OptioName { get; set; }
        public int? OptionEffect { get; set; }
        public int? ActionTypeId { get; set; }
        //public virtual ActionType ActionType { get; set; }
        //public virtual ICollection<History> Histories { get; set; }
        public ActionOptionDTO() { }
    }
}
