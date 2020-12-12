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


            ////DateTime datetimeOfBirth = DateTime.Parse(dateOfBirth);
            //User user = new User(name,
            //                     new Gender(genderUser),
            //                     DateTime.Parse(dateOfBirth),
            //                     new Location(countryUser));


            //Console.WriteLine("\n");
            //Console.WriteLine(user);
            //Console.WriteLine("\n -------------------- \n");

            var userController = new UserController(name);

            if (userController.CurrentUser.Gender==null || userController.CurrentUser.DateOfBirth==null || userController.CurrentUser.Location==null)
            {
                Console.WriteLine("Введите обязательные параметры пользователя:\n");
                var dateOfBirth = InputParametr("Дата рождения пользователя");
                var genderUser = InputParametr("Пол", 1);
                var countryUser = InputParametr("Страна пользователя");
                var locateUser = InputParametr("Место проживания пользователя");
                userController.SetRequiredParameters(new Gender(genderUser),
                                                     DateTime.Parse(dateOfBirth),
                                                     new Location(countryUser, locateUser));
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
