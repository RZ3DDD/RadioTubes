using System;


namespace RadioTubes.MBL.Model
{
    /// <summary>
    /// Пользователь (User)
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства... 
        private string firstName;
        private string middleName;
        private string lastName;

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
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }

        }

        /// <summary>
        /// Пол пользователя
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Место жительства пользователя
        /// </summary>
        public Location Location { get; set; }
        #endregion

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="userName"> Имя пользователя в системе </param>
        public User(string userName)
        {

            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException($"{nameof(userName)} не может быть пустым или содержать только пробел.", nameof(userName));
            }
            UserName = userName;
        }
        public override string ToString()
        {
            return $"{nameof(UserName)}: {UserName}\n{nameof(FirstName)}: {FirstName}\n{nameof(MiddleName)}: {MiddleName}\n{nameof(LastName)}: {LastName}\n{nameof(Gender)}: {Gender}\n{nameof(DateOfBirth)}: {DateOfBirth:dd/MM/yyyy}\n{nameof(Location)}: {Location}\n";
        }
    }
}
