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
                // מציגים את רשימת המשחקים
                Task<List<ActionOptionDTO>> list = UIMain.api.GetAllFoodAsync();
                ObjectsList foods = new ObjectsList("foods", list.Result.ToList<object>());
                foods.Show();
                Console.WriteLine();

                Console.WriteLine("Please enter food option ID:");
                int foodId = int.Parse(Console.ReadLine());
                const int DEAD_STATUS_ID = 4;
                Task<List<PetDTO>> playerPets = UIMain.api.GetPlayerPetsAsync();
                PetDTO p = playerPets.Result.Where(p => p.LifeStatusId != DEAD_STATUS_ID).FirstOrDefault();

                ActionOptionDTO actionOptionDTO = list.Result.Where(a => a.OptionId == foodId).FirstOrDefault();
                if (p == null)
                    Console.WriteLine("There is no active pet");
                else
                {
                    Task<bool> task = UIMain.api.DoActionFeedAsync(actionOptionDTO);
                    if (task.Result)
                        Console.WriteLine($"The pet played {actionOptionDTO.OptioName}");
                    else
                        Console.WriteLine("Something wrong happened!");
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Something wrong happened!");
                Console.WriteLine($"Error message: {e.Message}");
            }

            Console.WriteLine("Please press any key to get back to menu!");
            Console.ReadKey(true);

        }
    }
}
