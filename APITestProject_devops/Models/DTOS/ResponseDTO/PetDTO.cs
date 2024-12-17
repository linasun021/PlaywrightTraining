using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APITestProject.Models.DTOS.ResponseDTO
{
    public class CategoryDto
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }

    public class TagDto
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }

    public class PetDto
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("category")]
        public CategoryDto Category { get; set; } = new CategoryDto();

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("photoUrls")]
        public List<string> PhotoUrls { get; set; } = new List<string>();

        [JsonPropertyName("tags")]
        public List<TagDto> Tags { get; set; } = new List<TagDto>();

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;
    }
}
