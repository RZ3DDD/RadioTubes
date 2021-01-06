using System;

namespace RadioTubes.MBL.Model
{
    /// <summary>
    /// Базовый класс для классов конкретных компонентов радиотехники и электроники (резисторы, конденсаторы, лампы, транзисторы и т.п.о)
    /// </summary>
    public abstract class RadioComponent
    {
        protected RadioComponent() { }

        /// <summary>
        /// Производитель
        /// </summary>
        public string Manufacturer { get; set; } = "Unknown";
        /// <summary>
        /// Дата изготовления
        /// </summary>
        public DateTime DateOfManufactured { get; set; }
        /// <summary>
        /// Откуда "выдрали" или новьё
        /// </summary>
        public string ParentItem { get; set; } = "Newly";
    }
}
