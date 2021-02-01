using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTamagotchiApp.DataTransferObjects
{
   public class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerLastName { get; set; }
        public string PlayerEmail { get; set; }
        public DateTime PlayerBirthDay { get; set; }

        public PlayerDTO() { }
    }
}
