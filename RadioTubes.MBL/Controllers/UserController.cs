using RadioTubes.MBL.Model;
using RadioTubes.MBL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioTubes.MBL.Controller
{
    //static string userRoot = System.Environment.GetEnvironmentVariable("USERPROFILE");

    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBaseBinSerialization
    {
        readonly MBLSettings settings = new MBLSettings();

        /// <summary>
        /// Пользователи приложения.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь приложения
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="userName"> Пользователь приложения </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.UserName == userName);

            if (CurrentUser == null)
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
            return Load<List<User>>(settings.UserDataPath + "users.dat") ?? new List<User>();
        }

        /// <summary>
        /// Сохранить данные списка зарегистрированных пользователей.
        /// </summary>
        private void Save()
        {
            Save(settings.UserDataPath + "users.dat", Users);
        }

        /// <summary>
        /// Обновить данные текущего пользователя
        /// </summary>
        private void UpdateCurrentUserData()
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
        public void SetRequiredParameters(string gender,
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
                throw new ArgumentException($"{nameof(dateOfBirth)} - неправдоподобная дата рождения.", nameof(dateOfBirth));
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
        /// <param name="lastName"> Фамилия пользователя  </param>
        /// <param name="middleName"> Отчество пользователя </param>
        public void SetOptionalParameters(string firstName,
                                          string middleName,
                                          string lastName)
        {
            #region Проверка корректности вводимых параметров...
            // TODO: Продумать и реализовать проверки для ФИО
            if (string.IsNullOrWhiteSpace(firstName))
            {
                //throw new ArgumentException($"{nameof(firstName)} не может быть пустым или содержать только пробел.", nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                //throw new ArgumentException($"{nameof(lastName)} не может быть пустым или содержать только пробел.", nameof(lastName));
            }
            #endregion

            CurrentUser.FirstName = firstName;
            CurrentUser.LastName = lastName;
            CurrentUser.MiddleName = middleName;
            UpdateCurrentUserData();

        }

    }

}
