using System;

namespace RadioTubes.MBL.Model
{

    /// <summary>
    /// Пол пользователя (User gender)
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Наименование пола (User Gender name)
        /// </summary>
        public string Name { get; }


        /// <summary>
        /// Создать пол (конструктор)
        /// </summary>
        /// <param name="name"> Наименование пола </param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Наименование пола не может быть пустым или null!", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
