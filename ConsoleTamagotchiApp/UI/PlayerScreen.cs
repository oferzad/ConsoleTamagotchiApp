using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConsoleTamagotchiApp.DataTransferObjects;
using System.Threading.Tasks;


namespace TAMAGOTCHI.UI
{
    class PlayerScreen : Screen
    {
        public PlayerScreen() : base("Show Player")
        {


        }

        public override void Show()
        {
            base.Show();
            ObjectView showPlayer = new ObjectView("", UIMain.CurrentPlayer);
            showPlayer.Show();
            Console.WriteLine("Press A to see Player Animals or other key to go back!");
            char c = Console.ReadKey().KeyChar;
            if (c == 'a' || c == 'A')
            {
                //Read first the animals of the player
                Task<List<PetDTO>> t = UIMain.api.GetPlayerPetsAsync();
                Console.WriteLine("Reading player pets...");
                t.Wait();
                List<PetDTO> list = t.Result;
                if (list != null)
                {
                    //Create list to be displayed on screen
                    //Format the desired fields to be shown! (screen is not wide enough to show all)

                    List<Object> animals = list.ToList<Object>();
                    ObjectsList oList = new ObjectsList("pets", animals);
                    oList.Show();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("pets coud not be read!");
                }
                Console.WriteLine();


                Console.ReadKey();
            }

        }
    }
}
