
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                List<ActionOption> list = UIMain.db.GetAllGames();
                ObjectsList games = new ObjectsList("games", list.ToList<object>());
                games.Show();
                Console.WriteLine();
                Console.WriteLine("Please enter game option ID:");
                int gameId = int.Parse(Console.ReadLine());
                const int DEAD_STATUS_ID = 4;
                Pet p = UIMain.CurrentPlayer.Pets.Where(p => p.LifeStatusId != DEAD_STATUS_ID).FirstOrDefault();
                ActionOption actionOption = UIMain.db.ActionOptions.Where(a => a.OptionId == gameId).FirstOrDefault();
                if (p == null)
                    Console.WriteLine("There is no active pet");
                else
                {
                    p.DoActionPlay(actionOption);
                    Console.WriteLine($"The pet played {actionOption.OptioName}");
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
