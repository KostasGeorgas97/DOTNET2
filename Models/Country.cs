using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DOTNET2.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "Greece";
    
    }
} 