//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ConsoleTamagotchiApp
//{
//    class SignUpScreen : Screen
//    {
//        //קבועים
//        const int START_LEVELS = 50;
//        const int START_LIFE_ID = 1;
//        const int START_PET_WEIGHT = 3;
//        //פרטי השחקן
//        string playerName;
//        string playerLastName;
//        string playerEmail;
//        string playerGenedr;
//        DateTime playerBirthDay;
//        string playerUsername;
//        string playerPassword;
//        //פרטי החיה
//        string petName;

//        public SignUpScreen() : base("Sign Up") { }

//        public override void Show()
//        {
//            base.Show();
//            try
//            {
//                //קריאת פרטים מהמשתמש
//                Console.WriteLine("Please type your detailes");
//                Console.Write("First name: ");
//                playerName = Console.ReadLine();
//                Console.Write("Last name: ");
//                playerLastName = Console.ReadLine();
//                Console.Write("Email: ");
//                playerEmail = Console.ReadLine();
//                Console.Write("Gender: ");
//                playerGenedr = Console.ReadLine();
//                Console.Write("Birthday: ");
//                playerBirthDay = DateTime.Parse(Console.ReadLine());
//                Console.Write("Choose a user name: ");
//                playerUsername = Console.ReadLine();
//                Console.Write("Choose a password: ");
//                playerPassword = Console.ReadLine();
//                Console.Write("choose your pet's name: ");
//                petName = Console.ReadLine();

//                Player player = new Player()
//                {
//                    PlayerName = playerName,
//                    PlayerLastName = playerLastName,
//                    PlayerEmail = playerEmail,
//                    PlayerGenedr = playerGenedr,
//                    PlayerBirthDay = playerBirthDay,
//                    PlayerUsername = playerUsername,
//                    PlayerPassword = playerPassword
//                };
//                //הוספת השחקן
//                UIMain.db.AddPlayer(player);
//                UIMain.db.SaveChanges();

//                //playerId = player.PlayerId;
//                Pet pet = new Pet()
//                {
//                    //PlayerId = playerId,
//                    PetName = petName,
//                    HungerLevel = START_LEVELS,
//                    CleaningLevel = START_LEVELS,
//                    HappyLevel = START_LEVELS,
//                    LifeCycleId = START_LIFE_ID,
//                    LifeStatusId = START_LIFE_ID,
//                    PetBirthDay = DateTime.Now,
//                    PetWeight = START_PET_WEIGHT
//                };
//                //הוספת החיה        
//                player.AddPet(pet);
//                UIMain.db.SaveChanges();
//                Console.WriteLine("You are signed up!");

//                Console.WriteLine("Press any key to login!");
//                Console.ReadKey();

//            }
//            catch (Exception e)
//            {
//                Console.Clear();
//                Console.WriteLine("Something wrong happened");
//                Console.WriteLine($"Error massage: {e.Message}");
//            }
//        }
//    }
//}
