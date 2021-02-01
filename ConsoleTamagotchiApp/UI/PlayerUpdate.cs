//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;

//namespace ConsoleTamagotchiApp
//{
//    class PlayerUpdate : Screen
//    {
//        public PlayerUpdate() : base("Update player details")
//        {
//        }

//        public override void Show()
//        {
//            base.Show();

//            try
//            {
//                Console.WriteLine("Please choose one of the options 1-7");
//                Console.WriteLine("1. Change your pet's name");
//                Console.WriteLine("2. Change your username");
//                Console.WriteLine("3. Change your password");
//                Console.WriteLine("4. Change your first name");
//                Console.WriteLine("5. Change your last name");
//                Console.WriteLine("6. Change your email");
//                Console.WriteLine("7. Change your gender");

//                int option = 0;
//                int.TryParse(Console.ReadLine(), out option);
//                Pet pet = UIMain.CurrentPlayer.Pets.FirstOrDefault();
//                const int DEAD_STATUS_ID = 4;
//                switch (option)
//                {
//                    case 1:
//                        if (pet.LifeStatusId == DEAD_STATUS_ID)
//                            Console.WriteLine("There is no active pet");
//                        else
//                        {
//                            Console.WriteLine("Please type new pet's name: ");
//                            string newPetName = Console.ReadLine();
//                            pet.PetName = newPetName;
//                        }
//                        break;
//                    case 2:
//                        Console.WriteLine("Please Type new username: ");
//                        string newUserName = Console.ReadLine();
//                        UIMain.CurrentPlayer.PlayerUsername = newUserName;
//                        break;
//                    case 3:
//                        Console.WriteLine("Please Type new password: ");
//                        string newPassword = Console.ReadLine();
//                        UIMain.CurrentPlayer.PlayerPassword = newPassword;
//                        break;
//                    case 4:
//                        Console.WriteLine("Please Type your first name: ");
//                        string newfirstName = Console.ReadLine();
//                        UIMain.CurrentPlayer.PlayerName = newfirstName;
//                        break;
//                    case 5:
//                        Console.WriteLine("Please Type your last name: ");
//                        string newlastName = Console.ReadLine();
//                        UIMain.CurrentPlayer.PlayerLastName = newlastName;
//                        break;
//                    case 6:
//                        Console.WriteLine("Please Type your email: ");
//                        string newEmail = Console.ReadLine();
//                        UIMain.CurrentPlayer.PlayerEmail = newEmail;
//                        break;
//                    case 7:
//                        Console.WriteLine("Please Type your gender: ");
//                        string newGender = Console.ReadLine();
//                        UIMain.CurrentPlayer.PlayerGenedr = newGender;
//                        break;
//                    default:
//                        break;
//                }

//                UIMain.db.SaveChanges();
//                Console.WriteLine("The details changed successfully!");
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine($"The details change fail with error: {e.Message}!");
//            }

//            Console.WriteLine("Please press any key to get back to menu!");
//            Console.ReadKey(true);
//        }
//    }
//}
