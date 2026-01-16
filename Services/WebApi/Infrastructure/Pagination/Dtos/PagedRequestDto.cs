namespace WebApi.Infrastructure.Pagination.Dtos;

public class PagedRequestDto(int page, int pageSize, string? sortBy, string? sortDirection)
{
    public int Page { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
    public string? SortBy { get; set; } = sortBy;
    public string? SortDirection { get; set; } = sortDirection;
}
