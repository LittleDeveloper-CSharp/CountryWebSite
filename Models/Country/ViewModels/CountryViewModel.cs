using System.ComponentModel;

namespace CountryWebSite.Models.Country.ViewModels
{
    /// <summary>
    /// Краткая информация о стране
    /// </summary>
    public class CountryViewModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [DisplayName("Наименование")]
        public string Name { get; set; }

        /// <summary>
        /// Столица
        /// </summary>
        [DisplayName("Столица")]
        public string Capital { get; set; }
    }
}
