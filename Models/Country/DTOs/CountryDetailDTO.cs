using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CountryWebSite.Models.Country.DTOs
{
    /// <summary>
    /// Детальная информация о стране
    /// </summary>
    public class CountryDetailDTO
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [JsonPropertyName("name")]
        public CountryNameDTO Name { get; set; }

        /// <summary>
        /// Регион
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// Языки
        /// </summary>
        [JsonPropertyName("languages")]
        public Dictionary<string, string> Languages { get; set; }

        /// <summary>
        /// Столица
        /// </summary>
        [JsonPropertyName("capital")]
        public string[] Capital { get; set; }
    }
}
