using System.Text.Json.Serialization;

namespace ApiClientTemplate.Responses;

//TODO sample response class and you can delete it safely
public class SomeApiResponse
{
    [JsonPropertyName("totalArticles")]
    public int TotalArticles { get; set; }

    [JsonPropertyName("articles")]
    public List<SomeArticle> Articles { get; set; }
}