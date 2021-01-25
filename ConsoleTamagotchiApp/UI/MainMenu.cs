using System;
using System.Collections.Generic;
using System.Text;

namespace TAMAGOTCHI.UI
{
    class MainMenu : Menu
    {
        public MainMenu() : base($"Main Menu - {UIMain.CurrentPlayer.PlayerName} is logged in")
        {
            //Build items in main menu!
            AddItem("Show player", new PlayerScreen());
            AddItem("Update details", new PlayerUpdate());
            AddItem("Options Menu", new MenuOptions());
            AddItem("Play with your pet", new Play());
            AddItem("Feed your pet!", new Feed());
            AddItem("Clean your pet", new Clean());
        }
    }
}
