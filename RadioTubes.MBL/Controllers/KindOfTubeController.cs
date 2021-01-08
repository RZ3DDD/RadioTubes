using RadioTubes.MBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioTubes.MBL.Controllers
{
    public class KindOfTubeController : ControllerBaseBinSerialization

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
        /// <param engName="kindOfTubeEngName"> Тип лампы </param>
        public KindOfTubeController(string engName)
        {
            if (string.IsNullOrWhiteSpace(engName))
            {
                throw new ArgumentNullException("Наименование типа лампы на English не может быть пустым", nameof(engName));
            }

            KindOfTubes = GetKindOfTubesData();
            
            // Установить начальное значение счетчика для Id
            KindOfTube lastKindOfTube = KindOfTubes.LastOrDefault<KindOfTube>();
            if (lastKindOfTube == null)
            {
                KindOfTube.nextId = 0;
            }
            else
            {
                KindOfTube.nextId = lastKindOfTube.ID;
            }

            // Установить требуемый тип лампы текущим
            CurrentKindOfTube = KindOfTubes.SingleOrDefault(n => n.EngName == engName);
            if (CurrentKindOfTube == null)
            {
                CurrentKindOfTube = new KindOfTube(engName);
                KindOfTubes.Add(CurrentKindOfTube);
                Save();
            }

        }

        /// <summary>
        /// Получить список зарегистрированных типов ламп
        /// </summary>
        /// <returns> Список типов ламп зарегистрированных на текущий момент</returns>
        private List<KindOfTube> GetKindOfTubesData()
        {
            return Load<List<KindOfTube>>(settings.UserDataPath + "kind_of_tubes.dat") ?? new List<KindOfTube>();
        }

        /// <summary>
        /// Сохранить данные списка зарегистрированных типов ламп.
        /// </summary>
        private void Save()
        {
            Save(settings.UserDataPath + "kind_of_tubes.dat", KindOfTubes);
        }

        public void SetOptionalParameters(string cultName)
        {

            CurrentKindOfTube.CultName = cultName;
            UpdateCurrentKindOfTube();

        }

        /// <summary>
        /// Обновить данные текущего типа лампы
        /// </summary>
        private void UpdateCurrentKindOfTube()
        {
            KindOfTubes.Remove(CurrentKindOfTube);
            KindOfTubes.Add(CurrentKindOfTube);
            KindOfTubes.Sort();
            Save();
        }
    }
}
