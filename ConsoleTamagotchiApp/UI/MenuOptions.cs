using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TAMAGOTCHI.UI
{
    class MenuOptions : Screen
    {
        public MenuOptions() : base("Activities & Effect")
        {
        }

        public override void Show()
        {
            base.Show();
            try
            {
                //הצגת רשימת כל הפעולות
                List<ActionOption> list = UIMain.db.GetAllActions();
                ObjectsList actions = new ObjectsList("actions", list.ToList<object>());
                actions.Show();
                Console.WriteLine();
                Console.WriteLine("Press any key to go back to menu!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Something wrong happened");
                Console.WriteLine($"Error massage: {e.Message}");
            }
        }
    }
}
