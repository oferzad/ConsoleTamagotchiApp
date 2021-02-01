using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTamagotchiApp
{
    class Screen
    {
        public string Title { get; set; }
        public Screen(string title)
        {
            Title = title;
        }

        public virtual void Show()
        {
            Console.Clear();
            Console.WriteLine($"\t\t\t\t\t{Title}");
        }
    }
}
