using System;
using RadioTubes.MBL.Model;
using RadioTubes.MBL.Controller;

namespace RadioTubes.CMD
{
    class Program
    {

        static void Main()
        {

            var args = Environment.GetCommandLineArgs();
            Console.WriteLine($"\n__________________________________________________________________________________\n");
            Console.WriteLine($"Привет от приложения:\n{args[0]}\n__________________________________________________________________________________\n");

            var name = InputParametr("Имя пользователя");


            var userController = new UserController(name);

            if (userController.CurrentUser.Gender == null || userController.CurrentUser.DateOfBirth == null || userController.CurrentUser.Location == null)
            {
                Console.WriteLine("\nВведите обязательные параметры пользователя");
                Console.WriteLine(" -------------------- ");

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

                Console.WriteLine("\n -------------------- ");
                if (cki.Key == ConsoleKey.Y)
                {
                    userController.SetOptionalParameters(InputParametr("Имя пользователя"),
                                                         InputParametr("Отчество пользователя"),
                                                         InputParametr("Фамилия пользователя"));
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("\n -------------------- \n");

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
