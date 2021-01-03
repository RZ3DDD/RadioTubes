using System;

namespace RadioTubes.MBL.Model
{
    /// <summary>
    /// Тип лампы (диод, триод, двойной триод ...)
    /// </summary>
    class KindOfTube
    {
        public KindOfTube()
        {
            NameEng = "none";
            NameCult = "";
        }
        public KindOfTube(int id, string nameEng, string nameCult)
        {
            Id = id;
            NameEng = nameEng.ToLower();
            NameCult = nameCult;
        }

        public string ToString()
        {
            return $"Eng: {NameEng}   Cult: {NameCult}";
        }

        public int Id
        {
            get => default;
            set
            {
                Id = value;
            }
        }

        public string NameEng
        {
            get => default;
            set
            {
                NameEng = value;
            }
        }

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
