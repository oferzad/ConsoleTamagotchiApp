using ConsoleTamagotchiApp.DataTransferObjects;
using System;
using System.Threading.Tasks;

namespace TAMAGOTCHI.UI
{
    class SignUpScreen : Screen
    {

        //פרטי השחקן
        string playername;
        string playerlastname;
        string playeremail;
        string playergenedr;
        DateTime playerbirthDay;
        string playerusername;
        string playerpassword;
        //פרטי החיה


        public SignUpScreen() : base("Sign Up") { }

        public override void Show()
        {
            base.Show();

            if (UIMain.CurrentPlayer != null)
            {
                Console.WriteLine($"Currently, {0} is logged in. Press Y to log out or other key to go back to menu!");
                char c = Console.ReadKey().KeyChar;
                if (c == 'Y' || c == 'y')
                {
                    UIMain.CurrentPlayer = null;
                }
            }

            while (UIMain.CurrentPlayer == null)
            {
                //Clear screen again
                base.Show();

                Console.WriteLine("Please type your detailes");
                Console.Write("First name: ");
                playername = Console.ReadLine();
                Console.Write("Last name: ");
                playerlastname = Console.ReadLine();
                Console.Write("Email: ");
                playeremail = Console.ReadLine();
                Console.Write("Gender: ");
                playergenedr = Console.ReadLine();
                Console.Write("Birthday: ");
                playerbirthDay = DateTime.Parse(Console.ReadLine());
                Console.Write("Choose a user name: ");
                playerusername = Console.ReadLine();
                Console.Write("Choose a password: ");
                playerpassword = Console.ReadLine();

                PlayerDTO pdto = new PlayerDTO()
                {
                    PlayerName = playername,
                    PlayerLastName = playerlastname,
                    PlayerEmail = playeremail,
                    PlayerGender = playergenedr,
                    PlayerBirthDay = playerbirthDay,
                    PlayerUsername = playerusername,
                    PlayerPassword = playerpassword
                };

                Task<PlayerDTO> t = UIMain.api.SignUpAsync(pdto);
                Console.WriteLine("Wait while Signing Up" + ".....");
                t.Wait();
                UIMain.CurrentPlayer = t.Result;

                if (UIMain.CurrentPlayer == null)
                {
                    Console.WriteLine("Sorry, you can not sign up with this Email address. \n please try another address or try to log in");
                    Console.ReadKey();
                }

            }

            MainMenu menu = new MainMenu();
            menu.Show();
        }
    }
}
