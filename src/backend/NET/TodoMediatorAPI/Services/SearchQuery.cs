namespace TodoMediatorAPI;

public class SearchQuery
{
    public string? Keyword { get; set; }

    public int PageNumber { get; set; } = 1;
    
    public int PageSize { get; set; } = 10;
    
    public string? OrderBy { get; set; }
    
    public string? OrderDirection { get; set; }
}