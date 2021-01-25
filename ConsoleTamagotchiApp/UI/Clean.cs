using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TAMAGOTCHI.UI
{
    class Clean : Screen
    {
        public Clean() : base("Clean your pet")
        {
        }

        public override void Show()
        {
            base.Show();
            try
            {
                // מציגים את רשימת הנקיונות
                List<ActionOption> list = UIMain.db.GetAllCleans();
                ObjectsList cleans = new ObjectsList("cleans", list.ToList<object>());
                cleans.Show();
                Console.WriteLine();
                Console.WriteLine("Please enter clean option ID:");
                int cleanId = int.Parse(Console.ReadLine());
                const int DEAD_STATUS_ID = 4;
                Pet p = UIMain.CurrentPlayer.Pets.Where(p => p.LifeStatusId != DEAD_STATUS_ID).FirstOrDefault();
                ActionOption actionOption = UIMain.db.ActionOptions.Where(a => a.OptionId == cleanId).FirstOrDefault();
                if (p == null)
                    Console.WriteLine("There is no active pet");
                else
                {
                    p.DoActionClean(actionOption);
                    Console.WriteLine($"The pet {actionOption.OptioName}");
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
