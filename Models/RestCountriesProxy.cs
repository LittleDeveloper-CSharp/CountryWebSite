using CountryWebSite.Models.Country.DTOs;
using CountryWebSite.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CountryWebSite.Models
{
    /// <summary>
    /// Прокси сервиса RestCountries
    /// </summary>
    public class RestCountriesProxy : IRestCountries
    {
        /// <summary>
        /// Кеш приложения
        /// </summary>
        private IMemoryCache _cache;

        /// <summary>
        /// Сервис RestCountries
        /// </summary>
        private readonly RestCountriesService _restCountries;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="cache">Кеш</param>
        /// <param name="restCountries">Сервис RestCountries</param>
        public RestCountriesProxy(
            IMemoryCache cache,
            RestCountriesService restCountries)
        {
            _cache = cache;
            _restCountries = restCountries;
        }

        public async Task<CountryDTO[]> GetCountry(string query)
        {
            var countries = Array.Empty<CountryDTO>();

            if (_cache.TryGetValue("countries", out countries))
            {
                if (!string.IsNullOrEmpty(query))
                    countries = countries.Where(c => c.Name.Common.ToLower().Contains(query.ToLower())
                    || c.Name.Official.ToLower().Contains(query.ToLower()))
                        .ToArray();

                return countries;
            }

            countries = (await _restCountries.GetCountry(query)).ToArray();

            if (string.IsNullOrEmpty(query))
                _cache.Set("countries", countries, TimeSpan.FromMinutes(5));

            return countries;
        }

        public async Task<CountryDetailDTO> GetCountryDetail(string countryName)
        {
            if (_cache.TryGetValue(countryName, out CountryDetailDTO country))
            {
                return country;
            }

            country = await _restCountries.GetCountryDetail(countryName);

            _cache.Set(countryName, country, TimeSpan.FromMinutes(5));

            return country;
        }
    }
}
