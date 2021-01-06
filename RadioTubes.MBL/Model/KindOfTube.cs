using System;
using System.Threading;

namespace RadioTubes.MBL.Model
{
    /// <summary>
    /// Тип лампы (диод, триод, двойной триод ...)
    /// </summary>
    public class KindOfTube
    {
        static int nextId;
        public KindOfTube(string nameEng = "none", string nameCult = "")
        {
            Id = Interlocked.Increment(ref nextId);
            NameEng = nameEng.ToLower();
            NameCult = nameCult.ToLower();
        }

        /// <summary>
        /// Перезагрузка метода ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Eng: {NameEng}   Cult: {NameCult}";
        }

        /// <summary>
        ///  Id типа лампы
        /// </summary>
        public int Id
        {
            get => default;
            set
            {
                Id = value;
            }
        }

        /// <summary>
        /// Наименование типа лампы на English
        /// </summary>
        public string NameEng
        {
            get => default;
            set
            {
                NameEng = value;
            }
        }

        /// <summary>
        /// Наименование типа лампы на языке локали
        /// </summary>
        public string NameCult
        {
            get => default;
            set
            {
                NameCult = value;
            }
        }
    }
}
