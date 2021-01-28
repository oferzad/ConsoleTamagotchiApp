using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConsoleTamagotchiApp.DataTransferObjects;

namespace ConsoleTamagotchiApp
{
    class LoginScreen : Screen
    {
        public LoginScreen() : base("Login")
        {

        }

        public override void Show()
        {
            //Clear screen and set title (implemented by Screen Show)
            base.Show();

            //Check if we should logout first
            if (UIMain.CurrentPlayer != null)
            {
                Console.WriteLine($"Currently, {0} is logged in. Press Y to log out or other key to go back to menu!");
                char c = Console.ReadKey().KeyChar;
                if (c == 'Y' || c == 'y')
                {
                    UIMain.CurrentPlayer = null;
                }
            }

            //if user is still logged in, we should go out!= back to menu
            while (UIMain.CurrentPlayer == null)
            {
                //Clear screen again
                base.Show();

                Console.WriteLine($"Please enter your email: ");
                string email = Console.ReadLine();
                Console.WriteLine($"Please enter your password: ");
                string password = Console.ReadLine();

                Task<PlayerDTO> t = UIMain.api.LoginAsync(email, password);
                Console.WriteLine("Wait while logging in.....");
                t.Wait();
                UIMain.CurrentPlayer = t.Result;


                if (UIMain.CurrentPlayer == null)
                {
                    Console.WriteLine("Login fail!! Press any key to try again!");
                    Console.ReadKey();
                }
            }
            //Show main menu once user is logged in
            MainMenu menu = new MainMenu();
            menu.Show();
        }
    }
}
