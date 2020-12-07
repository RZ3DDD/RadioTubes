using RadioTubes.MBL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RadioTubes.CMD.Controller
{

    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"> Пользователь приложения </param>
        public UserController(User user) => User = user ?? throw new ArgumentNullException($"{nameof(user)} - Пользователь не может быть Null!", nameof(user));

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {

            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns> Пользователь приложения </returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                // TODO: Что делать, если пользователя не прочитали?
            }
        }
    }

}
