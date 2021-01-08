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
        static int nextId = 0;
        public KindOfTube(string engName = "none", string ccultName = "")
        {
            Id = nextId++; //Interlocked.Increment(ref nextId);
            EngName = engName;
            CultName = ccultName;
        }

        /// <summary>
        /// Перезагрузка метода ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Eng: {EngName}   Cult: {CultName}";
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
        public string EngName
        {
            get => default;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(value)} не может быть пустым или содержать только пробел.", nameof(value));
                }
                else
                {
                    EngName = value.Trim().ToLower();
                }
            }
        }

        /// <summary>
        /// Наименование типа лампы на языке локали
        /// </summary>
        private string cultName;

        public string  CultName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(cultName))
                {
                    return EngName;
                }
                else
                {
                    return cultName;
                }
            }
            set { cultName = value.Trim().ToLower(); }
        }

        //private string cultName;
        //public string CultName
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(cultName))
        //        {
        //            CultName = EngName;
        //        }
        //        else
        //        {
        //            CultName = cultName;
        //        }
        //    }
        //    set
        //    {
        //        cultName = value;
        //    }
        //}
    }
}
