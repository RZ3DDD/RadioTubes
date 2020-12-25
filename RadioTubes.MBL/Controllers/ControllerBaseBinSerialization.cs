using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RadioTubes.MBL.Controllers
{
    /// <summary>
    /// Базовый класс для бинарной сериализации
    /// </summary>
    public abstract class ControllerBaseBinSerialization
    {

        /// <summary>
        /// Сохранить объект в бинарном файле
        /// </summary>
        /// <param name="fileName"> Имя (с полным путём или без) бинарного файла </param>
        /// <param name="item"> Сериализуемый (сохраняемый) объект </param>
        protected static void Save(string fileName, object item)
        {

            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        /// <summary>
        /// Загрузка данных сериализованного объекта из бинарного файла
        /// </summary>
        /// <typeparam name="T"> Тип сериализованного объекта </typeparam>
        /// <param name="fileName"> Имя (с полным путём или без) бинарного файла хранящего сериализованный объект </param>
        /// <returns></returns>
        protected static T Load<T>(string fileName)
        {

            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default;
                }
            }
        }
    }
}
