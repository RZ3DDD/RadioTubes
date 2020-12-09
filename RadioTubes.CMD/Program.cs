using System;
using RadioTubes.MBL.Model;
using RadioTubes.MBL.Controller;

namespace RadioTubes.CMD
{
    class Program
    {

        static void Main()
        {

            var argv = Environment.GetCommandLineArgs();
            Console.WriteLine($"\n__________________________________________________________________________________\n");
            Console.WriteLine($"Привет от приложения:\n{argv[0]}\n__________________________________________________________________________________\n");

            var name = InputParametr("Имя пользователя");

            var dateOfBirth = InputParametr("Дата рождения пользователя");

            var genderUser = InputParametr("Пол");
            var countryUser = InputParametr("Страна пользователя");

            Console.WriteLine($"Вы ввели:");
            PrintParam(name);
            PrintParam(dateOfBirth);
            PrintParam(genderUser);
            PrintParam(countryUser);
            Console.WriteLine("\n -------------------- \n");

            DateTime datetimeOfBirth = DateTime.Parse(dateOfBirth);
            User user = new User(name,
                                 new Gender(genderUser),
                                 datetimeOfBirth,
                                 new Location(countryUser));

            
            Console.WriteLine("\n");
            Console.WriteLine(user);
            Console.WriteLine("\n -------------------- \n");

            var userController =  new UserController(user);
            userController.Save();

            var userCopy = new UserController().User;

            Console.WriteLine("\n");
            Console.WriteLine(userCopy);
            Console.WriteLine("\n -------------------- \n");

            Console.ReadLine();
        }

        public static string InputParametr(string text)
        {
            string parametr;

            do
            {
                Console.Write($"Корректно введите параметр <{text}>: ");
                parametr = Console.ReadLine();
            } while (parametr.Length <= 1);

            return parametr;
        }

        public static void PrintParam(string param)
        {
            Console.WriteLine($"{nameof(param)}: {param}");
        }
    }
}