using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTamagotchiApp.DataTransferObjects;
using ConsoleTamagotchiApp.WebServices;

namespace ConsoleTamagotchiApp
{
    class UIMain
    {
        //UI Main object is perfect for storing all UI state as it is initialized first and detroyed last.
        public static PlayerDTO CurrentPlayer { get; set; }
        public static TamagotchiWebAPI api { get; private set; }

        private Screen initialScreen;
        public UIMain(Screen initial)
        {
            this.initialScreen = initial;
        }
        public void ApplicationStart()
        {
            //Initialize web api
            api = new TamagotchiWebAPI(@"https://localhost:44396/api");
            CurrentPlayer = null;
            //Show Screen and start app!
            initialScreen.Show();
        }
    }
}
