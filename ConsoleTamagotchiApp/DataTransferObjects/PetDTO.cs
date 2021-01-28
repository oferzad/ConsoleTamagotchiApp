using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTamagotchiApp.DataTransferObjects
{
    public class PetDTO
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public int PlayerId { get; set; }
        public double PetWeight { get; set; }
        public DateTime PetBirthDay { get; set; }
        public int HungerLevel { get; set; }
        public int CleaningLevel { get; set; }
        public int HappyLevel { get; set; }
        public int LifeStatusId { get; set; }
        public int LifeCycleId { get; set; }

        public PetDTO() { }
    }
}
