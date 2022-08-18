using CountryWebSite.Models;
using CountryWebSite.Models.Country.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CountryWebSite.Controllers
{
    public class CountryController : Controller
    {
        private readonly IRestCountries _restCountries;

        public CountryController(IRestCountries restCountries)
        {
            _restCountries = restCountries;
        }

#nullable enable
        [HttpGet]
        public async Task<IActionResult> Index(string? query)
        {
            var models = await _restCountries.GetCountry(query);

            var countries = models.Select(c => new CountryViewModel
            {
                Capital = c.Capital == null ? "Отсутствует" : c.Capital.FirstOrDefault(),
                Name = c.Name.Official
            }).ToArray();

            ViewData.Add("search-query", query);

            return View(countries);
        }

        [HttpGet]
        public async Task<IActionResult> CountryDetails(string countryName)
        {
            var model = await _restCountries.GetCountryDetail(countryName);

            if (model == null)
                return View();

            var country = new CountryDetailViewModel
            {
                Capital = model.Capital == null ? "Отсутствует" : string.Join(',', model.Capital),
                Name = model.Name.Official,
                Languages = model.Languages == null ? "Отсутствует" : string.Join(',', model.Languages.Select(l => l.Value)),
                Region = model.Region
            };

            return View(country);
        }
    }
}
