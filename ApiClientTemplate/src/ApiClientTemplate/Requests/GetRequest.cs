namespace ApiClientTemplate.Requests;

//TODO sample request class and you can delete it safely
public class GetRequest
{
    public int? Id { get; set; }
    public string? Q { get; set; }
    public int? Skip { get; set; }
    public int? Take { get; set; }
    public int? Max { get; set; }
}