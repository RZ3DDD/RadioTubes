using RadioTubes.MBL.Controller;
using RadioTubes.MBL.Model;
using System;

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

            Console.WriteLine(new string('-', 25));
            var name = InputParametr("Имя пользователя");


            var userController = new UserController(name);

            if (userController.CurrentUser.Gender == null || userController.CurrentUser.DateOfBirth == null || userController.CurrentUser.Location == null)
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

                userController.SetRequiredParameters(InputParametr("Пол", 1),
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
                    userController.SetOptionalParameters(InputParametr("Имя пользователя"),
                                                         InputParametr("Отчество пользователя"),
                                                         InputParametr("Фамилия пользователя"));
                }
            }

            Console.WriteLine(new string('-', 25));
            Console.WriteLine();
            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine(new string('-', 25));
            Console.WriteLine("\n");
            
            Console.ReadLine();
        }

        public static string InputParametr(string text, int minLength = 2)
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
