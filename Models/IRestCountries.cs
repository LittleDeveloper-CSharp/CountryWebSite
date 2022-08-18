using CountryWebSite.Models.Country.DTOs;
using System.Threading.Tasks;

namespace CountryWebSite.Models
{
    /// <summary>
    /// Интерфейс для сервиса RestCountries
    /// </summary>
    public interface IRestCountries
    {
        /// <summary>
        /// Получить список стран
        /// </summary>
        /// <param name="query">Фильтр</param>
        /// <returns></returns>
        public Task<CountryDTO[]> GetCountry(string query);

        /// <summary>
        /// Получить детальную информацию о стране
        /// </summary>
        /// <param name="countryName">Наименование страны</param>
        /// <returns></returns>
        public Task<CountryDetailDTO> GetCountryDetail(string countryName);
    }
}
