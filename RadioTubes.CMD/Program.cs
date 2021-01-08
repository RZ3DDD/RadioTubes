using RadioTubes.MBL.Controllers;
using RadioTubes.MBL.Model;
using System;
using System.Threading;

namespace RadioTubes.CMD
{
    class Program
    {

        static void Main()
        {

            var args = Environment.GetCommandLineArgs();
            Console.WriteLine("\n" + new string('_', 51) + "\n");
            Console.WriteLine($"Привет от приложения:\n{args[0]}");
            Console.WriteLine(new string('_', 51));

            var loc = System.Globalization.CultureInfo.CurrentCulture;
            Console.WriteLine(loc);
            var uiloc = System.Globalization.CultureInfo.CurrentUICulture;
            Console.WriteLine(uiloc);
            var trloc = Thread.CurrentThread.CurrentUICulture;
            Console.WriteLine(trloc);

            UserController userController;
            KindOfTubeController kindOfTubeController;

            string menuItemPrefix = "--->  ";
            do
            {
                Console.WriteLine(new string('-', 45));
                Console.WriteLine("Задайте активность:");
                Console.WriteLine(menuItemPrefix + "U - ввести пользователя");
                Console.WriteLine(menuItemPrefix + "K - ввести тип лампы");
                Console.WriteLine(menuItemPrefix + "Q - выйти из программы");
                var cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.U:
                        userController = GetUser();
                        PrintCurrentUserInfo(userController);
                        break;

                    case ConsoleKey.K:
                        kindOfTubeController = GetKindOfTubeController();
                        PrintCurrentKindOfTube(kindOfTubeController);
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
                Console.WriteLine("\n");

            } while (true);


            //KindOfTube kindOfTube = new KindOfTube();
            //Console.WriteLine(kindOfTube);
            //KindOfTube kindOfTube1 = new KindOfTube();
            //kindOfTube1.CultName = "ИмениЛампыНет";
            //Console.WriteLine(kindOfTube1);
            //KindOfTube kindOfTube2 = new KindOfTube("diode", "диод");
            //Console.WriteLine(kindOfTube2);

            //Console.ReadLine();
        }

        private static UserController GetUser()
        {
            Console.WriteLine(new string('-', 25));
            var name = InputParametr("Имя пользователя");


            UserController userLocalController = new UserController(name);

            if (userLocalController.CurrentUser.Gender == null || userLocalController.CurrentUser.DateOfBirth == null || userLocalController.CurrentUser.Location == null)
            {
                Console.WriteLine("\nВведите обязательные параметры пользователя");
                Console.WriteLine(new string('-', 25));

                DateTime dateOfBirth;

                while (true)
                {
                    if (DateTime.TryParse(InputParametr("Дата рождения пользователя"), out dateOfBirth))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат даты рождения. Должно: DD.MM.YYYY или DD-MM-YYYY или DD/MM/YYYY");
                    }
                }

                userLocalController.SetRequiredParameters(InputParametr("Пол", 1),
                                                     dateOfBirth,
                                                     new Location(InputParametr("Страна пользователя"),
                                                                  InputParametr("Населённый пункт проживания пользователя")));

                ConsoleKeyInfo cki = new ConsoleKeyInfo('y', ConsoleKey.Y, false, false, false);
                Console.Write("\n\nБудете вводить необязательные параметры пользователя? (Y/n): ");
                do
                {
                    var ckiTemp = cki;
                    cki = Console.ReadKey(true);
                    if (ckiTemp.Key == ConsoleKey.Y && cki.Key == ConsoleKey.Enter)
                    {
                        cki = new ConsoleKeyInfo('y', ConsoleKey.Y, false, false, false);
                        break;
                    }
                    if (cki.Key == ConsoleKey.Enter) cki = ckiTemp;

                } while (cki.Key != ConsoleKey.Y && cki.Key != ConsoleKey.N);

                Console.WriteLine(new string('-', 25));
                if (cki.Key == ConsoleKey.Y)
                {
                    userLocalController.SetOptionalParameters(InputParametr("Имя пользователя"),
                                                         InputParametr("Отчество пользователя"),
                                                         InputParametr("Фамилия пользователя"));
                }
            }
            return userLocalController;
        }

        private static void PrintCurrentUserInfo(UserController currentUserController)
        {
            Console.WriteLine(new string('-', 25));
            Console.WriteLine("Информация о текущем пользователе");
            Console.WriteLine(new string('-', 25));
            Console.WriteLine();
            Console.WriteLine(currentUserController.CurrentUser);
            Console.WriteLine(new string('-', 25));
            return;
        }

        private static KindOfTubeController GetKindOfTubeController()
        {
            Console.WriteLine(new string('-', 25));

            string kindOfTubeName = InputParametr("Наименование типа лампы на Eng");
            KindOfTubeController kindOfTubeLocalController = new KindOfTubeController(kindOfTubeName);

            if (string.IsNullOrWhiteSpace(kindOfTubeLocalController.CurrentKindOfTube.CultName)
                || kindOfTubeLocalController.CurrentKindOfTube.CultName == kindOfTubeLocalController.CurrentKindOfTube.EngName)
            {
                ConsoleKeyInfo cki = new ConsoleKeyInfo('y', ConsoleKey.Y, false, false, false);
                Console.Write("\nБудете вводить наименование типа лампы на русском? (Y/n): ");
                do
                {
                    var ckiTemp = cki;
                    cki = Console.ReadKey(true);
                    if (ckiTemp.Key == ConsoleKey.Y && cki.Key == ConsoleKey.Enter)
                    {
                        cki = new ConsoleKeyInfo('y', ConsoleKey.Y, false, false, false);
                        break;
                    }
                    if (cki.Key == ConsoleKey.Enter) cki = ckiTemp;

                } while (cki.Key != ConsoleKey.Y && cki.Key != ConsoleKey.N);
                Console.WriteLine(new string('-', 25));
                if (cki.Key == ConsoleKey.Y)
                {
                    kindOfTubeLocalController.SetOptionalParameters(InputParametr("Наименование типа лампы на русском"));
                }
            }

            return kindOfTubeLocalController;
        }

        private static void PrintCurrentKindOfTube(KindOfTubeController currentKindOfTubeController)
        {
            Console.WriteLine(new string('-', 25));
            Console.WriteLine("Информация о текущем пользователе");
            Console.WriteLine(new string('-', 25));
            Console.WriteLine();
            Console.WriteLine(currentKindOfTubeController.CurrentKindOfTube);
            Console.WriteLine(new string('-', 25));
            return;
        }



        private static string InputParametr(string text, int minLength = 2)
        {
            string parametr;

            do
            {
                Console.Write($"Корректно введите параметр <{text}>: ");
                parametr = Console.ReadLine();
            } while (parametr.Length < minLength);

            return parametr;
        }
    }
}
