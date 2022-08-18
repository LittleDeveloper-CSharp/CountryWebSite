using System.Text.Json.Serialization;

namespace CountryWebSite.Models.Country.DTOs
{
    /// <summary>
    /// Вспомогательный класс для наименования страны
    /// </summary>
    public class CountryNameDTO
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [JsonPropertyName("common")]
        public string Common { get; set; }

        /// <summary>
        /// Официальное название
        /// </summary>
        [JsonPropertyName("official")]
        public string Official { get; set; }
    }
}
