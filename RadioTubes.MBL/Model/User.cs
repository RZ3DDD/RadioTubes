using System;


namespace RadioTubes.MBL.Model
{
    /// <summary>
    /// Пользователь (User)
    /// </summary>
    [Serializable]
    class User
    {
        #region Свойства... 
        private string firstName;
        private string middleName;
        private string secondName;

        /// <summary>
        /// Имя пользователя в системе
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Имя пользователя в миру
        /// </summary>
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }

        }

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        public string MiddleName
        {
            get
            {
                return middleName;
            }

            set
            {
                middleName = value;
            }

        }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string SecondName
        {
            get
            {
                return secondName;
            }

            set
            {
                secondName = value;
            }

        }

        /// <summary>
        /// Пол пользователя
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; }

        /// <summary>
        /// Место жительства пользователя
        /// </summary>
        public Location Location { get; set; }
        #endregion

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="userName"> Имя пользователя в системе </param>
        /// <param name="gender"> Пол пользователя </param>
        /// <param name="dateOfBirth"> Дата рождения </param>
        /// <param name="location"> Место жительства </param>
        public User(string userName,
                    Gender gender,
                    DateTime dateOfBirth,
                    Location location)
        {
            #region Проверка корректности вводмимых параметров...
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException($"{nameof(userName)} не может быть пустым или содержать только пробел.", nameof(userName));
            }

            if (gender is null)
            {
                throw new ArgumentNullException(nameof(gender));
            }

            if (dateOfBirth > DateTime.Now || dateOfBirth < DateTime.Parse("01.01.1920"))
            {
                throw new ArgumentException($"{nameof(dateOfBirth)} - не правдоподобная дата рождения.", nameof(dateOfBirth));
            }

            //if (!DateTime.TryParse(dateOfBirth, out DateTime result))
            //{
            //    throw new ArgumentException($"{nameof(dateOfBirth)}, результат = {nameof(result)} - некорректная дата.", nameof(dateOfBirth));
            //}

            if (location is null)
            {
                throw new ArgumentNullException($"Location: {nameof(location)} - не указано место проживания.", nameof(location));
            }
            #endregion

            UserName = userName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Location = location;
        }

        // TODO: Переопределить ToString() для User
        public override string ToString()
        {
            return base.ToString();
        }
    }
}