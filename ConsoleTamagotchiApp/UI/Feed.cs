using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TAMAGOTCHI.UI
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
                List<ActionOption> list = UIMain.db.GetFoodList();
                ObjectsList foods = new ObjectsList("Food", list.ToList<object>());
                foods.Show();
                Console.WriteLine();

                Console.WriteLine("please enter food ID:");
                int foodid = int.Parse(Console.ReadLine());

                const int DEADid = 4;
                Pet p = UIMain.CurrentPlayer.Pets.Where(p => p.LifeStatusId != DEADid).FirstOrDefault();
                ActionOption ao = UIMain.db.ActionOptions.Where(a => a.OptionId == foodid).FirstOrDefault();
                if (p == null)
                {
                    Console.WriteLine("you do not own an active pet:(");
                }
                else
                {
                    p.feed(ao);
                    Console.WriteLine("you fed your pet {0}. \n YUMMY!", ao.OptioName);
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
