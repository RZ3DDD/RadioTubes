using System;


namespace RadioTubes.CMD
{
    class Program
    {

        static void Main()
        {

            var argv = Environment.GetCommandLineArgs();
            Console.WriteLine($"\n__________________________________________________________________________________\n");
            Console.WriteLine($"Привет от приложения:\n{argv[0]}\n__________________________________________________________________________________\n");

            Console.Write("Введите имя пользователя: ");
            var name = Console.ReadLine();
            Console.WriteLine($"{nameof(name)}: {name}");
            Console.ReadLine();

            Console.Write("Введите страну пользователя: ");
            var country = Console.ReadLine();

            Console.WriteLine($"{nameof(country)}: {country}");
            Console.ReadLine();
        }
    }
}
