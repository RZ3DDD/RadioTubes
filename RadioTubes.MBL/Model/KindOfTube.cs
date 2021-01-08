using System;
using System.Threading;

namespace RadioTubes.MBL.Model
{
    /// <summary>
    /// Тип лампы (диод, триод, двойной триод ...)
    /// </summary>
    [Serializable]
    public class KindOfTube
    {
        public static int nextId;
        readonly int Id;
        readonly private string englishName;
        private string cultureName;
        
        public KindOfTube(string engName = "none", string cultName = "")
        {
            Id = Interlocked.Increment(ref nextId);
            if (string.IsNullOrWhiteSpace(engName))
            {
                throw new ArgumentException($"{nameof(engName)} = \"{engName}\" не может быть пустым или содержать только пробел.", nameof(engName));
            }
            else
            {
                englishName = engName.Trim().ToLower();
            }
            //TODO: как проверить, что в строке буквы только для English или другой локали и несколько других символов?
            cultureName = cultName.Trim().ToLower();
        }

        /// <summary>
        /// Перезагрузка метода ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {ID}   Eng: {EngName}   Cult: {CultName}";
        }

        /// <summary>
        ///  Id типа лампы
        /// </summary>
        public int ID
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Наименование типа лампы на English
        /// </summary>
        public string EngName
        {
            get => englishName;
        }

        /// <summary>
        /// Наименование типа лампы на языке локали
        /// </summary>
        public string CultName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(cultureName))
                {
                    return EngName;
                }
                else
                {
                    return cultureName;
                }
            }
            set
            {
                cultureName = value.Trim().ToLower();
            }
        }
    }
}
