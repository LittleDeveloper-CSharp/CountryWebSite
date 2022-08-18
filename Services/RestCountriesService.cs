using CountryWebSite.Models;
using CountryWebSite.Models.Country.DTOs;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountryWebSite.Services
{
    /// <summary>
    /// Сервис для работы с RestCountries
    /// </summary>
    public class RestCountriesService : IRestCountries
    {
        /// <summary>
        /// Url сервиса
        /// </summary>
        private const string URL = "https://restcountries.com";

        /// <summary>
        /// Путь к апи
        /// </summary>
        private const string PATH = "/v3.1";

        /// <summary>
        /// Http клиент
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="httpClient">Http клиент</param>
        public RestCountriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CountryDTO[]> GetCountry(string query)
        {
            try
            {
                var path = $"{URL}{PATH}/all";

                var responce = await _httpClient.GetAsync(path);

                var countries = Array.Empty<CountryDTO>();

                if (responce.IsSuccessStatusCode)
                {
                    var content = await responce.Content.ReadAsStringAsync();

                    countries = JsonSerializer.Deserialize<CountryDTO[]>(content);
                }

                countries = countries.OrderBy(x => x.Name.Official)
                    .ToArray();

                return countries;
            }
            catch
            {
                return Array.Empty<CountryDTO>();
            }
        }

        public async Task<CountryDetailDTO> GetCountryDetail(string countryName)
        {
            try
            {
                var path = $"{URL}{PATH}/name/{countryName}";

                var responce = await _httpClient.GetAsync(path);

                CountryDetailDTO country = null;

                if (responce.IsSuccessStatusCode)
                {
                    var content = await responce.Content.ReadAsStringAsync();

                    country = JsonSerializer.Deserialize<CountryDetailDTO[]>(content)
                        .SingleOrDefault();
                }

                return country;
            }
            catch
            {
                return null;
            }
        }
    }
}
