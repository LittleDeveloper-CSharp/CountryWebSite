using System.Text.Json.Serialization;

namespace CountryWebSite.Models.Country.DTOs
{
    /// <summary>
    /// Краткая информация о стране
    /// </summary>
    public class CountryDTO
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [JsonPropertyName("name")]
        public CountryNameDTO Name { get; set; }

        /// <summary>
        /// Столица
        /// </summary>
        [JsonPropertyName("capital")]
        public string[] Capital { get; set; }
    }
}
