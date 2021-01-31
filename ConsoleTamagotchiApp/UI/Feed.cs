using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTamagotchiApp.DataTransferObjects;
using System.Threading.Tasks;

namespace ConsoleTamagotchiApp
{
    class Feed : Screen
    {
        public Feed() : base("Feed Your Pet! \n")
        {
        }

        public override void Show()
        {
            base.Show();
            try
            {
                Task<List<ActionOptionDTO>> list = UIMain.api.GetAllFoodAsync();
                ObjectsList foods = new ObjectsList("Food", list.Result.ToList<object>());
                foods.Show();
                Console.WriteLine();

                Console.WriteLine("please enter food ID:");
                int foodId = int.Parse(Console.ReadLine());
                const int DEAD_STATUS_ID = 4;
                Task<List<PetDTO>> playerPets = UIMain.api.GetPlayerPetsAsync();
                PetDTO p = playerPets.Result.Where(p => p.LifeStatusId != DEAD_STATUS_ID).FirstOrDefault();
                ActionOptionDTO actionOptionDTO = list.Result.Where(a => a.OptionId == foodId).FirstOrDefault();
                if (p == null)
                    Console.WriteLine("you do not own an active pet:(");
                else
                {
                    Task<bool> task = UIMain.api.DoActionFeedAsync(actionOptionDTO);
                    if (task.Result)
                        Console.WriteLine($"The pet ate {actionOptionDTO.OptioName}. \n YUMMY!");
                    else
                        Console.WriteLine("Something wrong happened!");
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("OH NO! \n somthing went worng");
                Console.WriteLine($"Error Message: {e.Message}");
            }

            Console.WriteLine("please press any key to go back to menu :)");
            Console.ReadKey(true);

        }
    }
}
