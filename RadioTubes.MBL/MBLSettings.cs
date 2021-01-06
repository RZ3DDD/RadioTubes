using System;
using System.IO;
using RadioTubes.MBL.Properties;

namespace RadioTubes.MBL
{
    /// <summary>
    /// Установочные (настроечные) параметры
    /// Необходимо в Свойствах проекта в разделе Параметры вручную добавить такие же параметры, если их там нет, с пустыми значениями
    /// </summary>
    public class MBLSettings
    {
        private readonly string userRootDir;
        private readonly string userAppDataRoaming;
        private readonly string userAppDataLocal;
        private readonly string userDataPath;

        public MBLSettings()
        {

            userRootDir = GetDefaultSetting("USERPROFILE", "userRootDir");
            userAppDataRoaming = GetDefaultSetting("APPDATA", "userAppDataRoaming");
            userAppDataLocal = GetDefaultSetting("LOCALAPPDATA", "userAppDataLocal");

            userDataPath = Settings.Default["userDataPath"] as string;
            string programName;
            try
            {
                programName = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
            }
            catch (NullReferenceException)
            {
                programName = "RadioTubesTest12345678";
            }
            string currentUserDataPath = userAppDataLocal + "\\" + programName.Remove(programName.Length - 8) + @"\Data\";
            if (string.IsNullOrEmpty(userDataPath) || !currentUserDataPath.Equals(userDataPath))
            {
                userDataPath = currentUserDataPath;
                Settings.Default["userDataPath"] = userDataPath;
                Settings.Default.Save();
            }
            if (!Directory.Exists(userDataPath)) Directory.CreateDirectory(userDataPath);

        }

        /// <summary>
        /// Получить значения параметров по умолчанию (прежде установленных)
        /// </summary>
        /// <param name="envVar"> Имя системной переменной окружения </param>
        /// <param name="defParName"> Имя параметра хранимого средствами класса System.Settings секции userSettings </param>
        /// <returns></returns>
        private string GetDefaultSetting(string envVar, string defParName)
        {
            string currentDefaultParameter = Settings.Default[defParName] as string;
            string currentEnvVar = Environment.GetEnvironmentVariable(envVar);
            if (string.IsNullOrEmpty(currentDefaultParameter) || !currentDefaultParameter.Equals(currentEnvVar))
            {
                Settings.Default[defParName] = currentEnvVar;
                Settings.Default.Save();
                return currentEnvVar;
            }
            else
            {
                return currentDefaultParameter;
            }
        }

        /// <summary>
        /// Папка текущего пользователя в системе
        /// </summary>
        public string UserRootDir {
            get { return userRootDir; }
        }

        /// <summary>
        /// Полный путь к папке текущего пользователя ...AppData\Roaming
        /// </summary>
        public string UserAppDataRoaming {
            get { return userAppDataRoaming; }
        }

        /// <summary>
        /// Полный путь к папке текущего пользователя ...AppData\Local
        /// </summary>
        public string UserAppDataLocal {
            get { return userAppDataLocal; }
        }

        /// <summary>
        /// Полный путь к папке текущего пользователя для хранения данных
        /// </summary>
        public string UserDataPath {
            get { return userDataPath; }
        }
    }
}
