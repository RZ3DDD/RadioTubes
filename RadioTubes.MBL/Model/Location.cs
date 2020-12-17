using System;


namespace RadioTubes.MBL.Model
{
    /// <summary>
    /// Место жительства (Location)
    /// </summary>
    [Serializable]
    public class Location
    {
        /// <summary>
        /// Страна проживания пользователя
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Населённый пункт жительства пользователя
        /// </summary>
        public string Locality { get; }


        /// <summary>
        /// Создать место жительства пользователя
        /// </summary>
        /// <param name="country"> Страна проживания </param>
        /// <param name="locality"> Населённый пункт </param>
        public Location(string country, string locality)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentNullException("Страна проживания должна быть указана обязательно!", nameof(country));
            }
            Country = country;

            if (string.IsNullOrWhiteSpace(locality))
            {
                throw new ArgumentNullException("Населённый пункт должен быть указан обязательно!", nameof(locality));
            }
            Locality = locality;
        }

        public override string ToString()
        {
            return $"Страна: {this.Country}.  Населённый пункт: {this.Locality}.";
        }
    }
}
