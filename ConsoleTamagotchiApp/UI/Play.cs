
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTamagotchiApp.DataTransferObjects;
using System.Threading.Tasks;

namespace TAMAGOTCHI.UI
{
    class Play : Screen
    {
        public Play() : base("play with your pet")
        {
        }

        public override void Show()
        {
            base.Show();
            try
            {
                // מציגים את רשימת המשחקים
                Task<List<ActionOptionDTO>> list = UIMain.api.GetAllGamesAsync();
                ObjectsList games = new ObjectsList("games", list.Result.ToList<object>());
                games.Show();
                Console.WriteLine();

                Console.WriteLine("Please enter game option ID:");
                int gameId = int.Parse(Console.ReadLine());
                const int DEAD_STATUS_ID = 4;
                Task<List<PetDTO>> playerPets = UIMain.api.GetPlayerPetsAsync();
                PetDTO p = playerPets.Result.Where(p => p.LifeStatusId != DEAD_STATUS_ID).FirstOrDefault();

                ActionOptionDTO actionOptionDTO = list.Result.Where(a => a.OptionId == gameId).FirstOrDefault();
                if (p == null)
                    Console.WriteLine("There is no active pet");
                else
                {
                    Task<bool> task = UIMain.api.DoActionPlayAsync(actionOptionDTO);
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
