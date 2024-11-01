namespace ORC.CenterPoint.API.Application.Features.Common.Queries;

public class PaginationResponseBase
{
    #region Properties
    /// <summary>
    /// Contains total items on query database
    /// </summary>
    /// <example>48</example>
    public long TotalItems { get; set; }

    /// <summary>
    /// Shows current page number
    /// </summary>
    /// <example>1</example>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Contains items number on de current page
    /// </summary>
    /// <example>10</example>
    public int PageItemsNumber { get; set; }

    /// <summary>
    /// Contains total page number on query
    /// </summary>
    /// <example>5</example>
    public double TotalPages => Math.Ceiling((double)TotalItems / (double)PageItemsNumber);
    #endregion
}