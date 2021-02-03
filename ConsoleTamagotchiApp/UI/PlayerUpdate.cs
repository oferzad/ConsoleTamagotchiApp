using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConsoleTamagotchiApp.DataTransferObjects;
using System.Threading.Tasks;

namespace ConsoleTamagotchiApp
{
    class PlayerUpdate : Screen
    {
        string playername;
        string playerlastname;
        string playeremail;
        string playerusername;
        string playerpassword;

        public PlayerUpdate() : base("Update player details")
        {
        }

        public override void Show()
        {
            base.Show();

            try
            {
                Console.WriteLine("please enter your details ");
                Console.WriteLine("Please Type new username: ");
                string newUserName = Console.ReadLine();
                UIMain.CurrentPlayer.PlayerUsername = newUserName;


                Console.WriteLine("Please Type new password: ");
                string newPassword = Console.ReadLine();
                UIMain.CurrentPlayer.PlayerPassword = newPassword;


                Console.WriteLine("Please Type your first name: ");
                string newfirstName = Console.ReadLine();
                UIMain.CurrentPlayer.PlayerName = newfirstName;


                Console.WriteLine("Please Type your last name: ");
                string newlastName = Console.ReadLine();

                Console.WriteLine("Please Type your email: ");
                string newEmail = Console.ReadLine();
                UIMain.CurrentPlayer.PlayerEmail = newEmail;

                PlayerDTO player = new PlayerDTO()
                {
                    PlayerName = newfirstName,
                    PlayerLastName = newlastName,
                    PlayerEmail = newEmail,
                    PlayerUsername = newUserName,
                    PlayerPassword = newPassword

                };
                Task t = UIMain.api.UpdateAsync(player);
                Console.WriteLine("Wait while Updating" + ".....");
                t.Wait();
             
                Console.WriteLine("The details changed successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"The details change fail with error: {e.Message}!");
            }

                Console.WriteLine("Please press any key to get back to menu!");
                Console.ReadKey(true);
        }
    }
}
