using RadioTubes.MBL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace RadioTubes.MBL.Controller
{

    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>

        public List<User> Users { get; }
        public User CurrentUser { get; }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="userName"> Пользователь приложения </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользоваителя не может быть пустым", nameof(userName));
            }

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.UserName == userName);
            //TODO: Чем плох List.Find(...)? 
            //CurrentUser = Users.Find(u => u.UserName == userName);
            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                Save();
            }
            
        }

        /// <summary>
        /// Получить список зарегистрированных пользователей
        /// </summary>
        /// <returns> Список пользователей зарегистрированных на текущий момент</returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(fs.Length>0 && formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return  new List<User>();
                }
            }
        }

        /// <summary>
        /// Сохранить данные списка зарегистрированных пользователей.
        /// </summary>
        public void Save()
        {

            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }

       /// <summary>
       /// Обновить данные текущего пользователя
       /// </summary>
        public void UpdateCurrentUserData()
        {
            Users.Remove(CurrentUser);
            Users.Add(CurrentUser);
            //Users.Sort();
            Save();
        }

        /// <summary>
        /// Установить обязательные параметры пользователя
        /// </summary>
        /// <param name="gender"> Пол пользователя </param>
        /// <param name="dateOfBirth"> Дата рождения пользователя </param>
        /// <param name="location"> Место жительства пользователя </param>
        public void SetRequiredParameters (string gender,
                                           DateTime dateOfBirth,
                                           Location location)
        {
            #region Проверка корректности вводимых параметров...
            if (gender is null)
            {
                throw new ArgumentNullException(nameof(gender));
            }

            if (dateOfBirth > DateTime.Now || dateOfBirth < DateTime.Parse("01.01.1920"))
            {
                throw new ArgumentException($"{nameof(dateOfBirth)} - не правдоподобная дата рождения.", nameof(dateOfBirth));
            }

            if (location is null)
            {
                throw new ArgumentNullException($"Location: {nameof(location)} - не указано место проживания.", nameof(location));
            }
            #endregion

            CurrentUser.Gender = new Gender(gender);
            CurrentUser.DateOfBirth = dateOfBirth;
            CurrentUser.Location = location;
            UpdateCurrentUserData();
        }

        /// <summary>
        /// Установить необязательные параметры пользователя
        /// </summary>
        /// <param name="firstName"> Имя пользователя </param>
        /// <param name="secondName"> Фамилия пользователя  </param>
        /// <param name="middleName"> Отчество пользователя </param>
        public void SetOptionalParameters(string firstName,
                                          string middleName,
                                          string secondName)
        {
            #region Проверка корректности вводимых параметров...
            if (string.IsNullOrWhiteSpace(firstName))
            {
                //throw new ArgumentException($"{nameof(firstName)} не может быть пустым или содержать только пробел.", nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(secondName))
            {
                //throw new ArgumentException($"{nameof(secondName)} не может быть пустым или содержать только пробел.", nameof(secondName));
            }
            #endregion

            CurrentUser.FirstName = firstName;
            CurrentUser.SecondName = secondName;
            CurrentUser.MiddleName = middleName;
            UpdateCurrentUserData();

        }

    }

}
