using System.ComponentModel;

namespace CountryWebSite.Models.Country.ViewModels
{
    /// <summary>
    /// Детальная информация о стране
    /// </summary>
    public class CountryDetailViewModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [DisplayName("Название")]
        public string Name { get; set; }

        /// <summary>
        /// Регион
        /// </summary>
        [DisplayName("Регион")]
        public string Region { get; set; }

        /// <summary>
        /// Языки
        /// </summary>
        [DisplayName("Языки")]
        public string Languages { get; set; }

        /// <summary>
        /// Столица
        /// </summary>
        [DisplayName("Столица")]
        public string Capital { get; set; }
    }
}
