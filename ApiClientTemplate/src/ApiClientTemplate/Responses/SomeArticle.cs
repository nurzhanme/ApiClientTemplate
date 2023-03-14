using System.Text.Json.Serialization;

namespace ApiClientTemplate.Responses;

//TODO sample response class and you can delete it safely
public class SomeArticle
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("publishedAt")]
    public DateTime PublishedAt { get; set; }
}