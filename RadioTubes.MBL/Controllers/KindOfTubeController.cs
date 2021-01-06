using RadioTubes.MBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioTubes.MBL.Controllers
{
    class KindOfTubeController : ControllerBaseBinSerialization

    {
        readonly MBLSettings settings = new MBLSettings();

        /// <summary>
        /// Список типов ламп.
        /// </summary>
        public List<KindOfTube> KindOfTubes { get; }

        /// <summary>
        /// Текущий тип лампы
        /// </summary>
        public KindOfTube CurrentKindOfTube { get; }

        /// <summary>
        /// Создание нового контроллера типа лампы.
        /// </summary>
        /// <param name="userName"> Пользователь приложения </param>
        public KindOfTubeController(string engName)
        {
            if (string.IsNullOrWhiteSpace(engName))
            {
                throw new ArgumentNullException("Наименование типа лампы на English не может быть пустым", nameof(engName));
            }

            KindOfTubes = GetKindOfTubesData();
            CurrentKindOfTube = KindOfTubes.SingleOrDefault(n => n.NameEng == engName);

            if (CurrentKindOfTube == null)
            {
                CurrentKindOfTube = new KindOfTube(engName);
                KindOfTubes.Add(CurrentKindOfTube);
                Save();
            }

        }

        /// <summary>
        /// Получить список зарегистрированных пользователей
        /// </summary>
        /// <returns> Список пользователей зарегистрированных на текущий момент</returns>
        private List<KindOfTube> GetKindOfTubesData()
        {
            return Load<List<KindOfTube>>(settings.UserDataPath + "kind_of_tubes.dat") ?? new List<KindOfTube>();
        }

        /// <summary>
        /// Сохранить данные списка зарегистрированных пользователей.
        /// </summary>
        private void Save()
        {
            Save(settings.UserDataPath + "kind_of_tubes.dat", KindOfTubes);
        }

        /// <summary>
        /// Обновить данные текущего пользователя
        /// </summary>
        private void UpdateCurrentKindOfTube()
        {
            KindOfTubes.Remove(CurrentKindOfTube);
            KindOfTubes.Add(CurrentKindOfTube);
            Save();
        }
    }
}
