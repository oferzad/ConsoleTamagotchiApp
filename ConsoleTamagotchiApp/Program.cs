using ConsoleTamagotchiApp.WebServices;
using System;
using System.Threading.Tasks;

namespace ConsoleTamagotchiApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TamagotchiWebAPI tamagotchiWebAPI = new TamagotchiWebAPI(@"https://localhost:44396/api");
            Task<string> t = tamagotchiWebAPI.GetTestAsync();
            t.Wait();
            Console.WriteLine(t.Result);
            Console.ReadKey();  
        }
    }
}
