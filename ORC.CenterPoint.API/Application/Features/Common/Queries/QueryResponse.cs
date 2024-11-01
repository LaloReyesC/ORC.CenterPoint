namespace ORC.CenterPoint.API.Application.Features.Common.Queries;

public class QueryResponse<T>
    : IResponse where T : class
{
    #region Properties
    /// <inheritdoc/>
    public OperationStateEnum StateCode { get; set; }

    /// <inheritdoc/>
    public string State => StateCode.ToString();

    /// <summary>
    /// Contains a readonly list of items founded when query returns information
    /// </summary>
    public IReadOnlyList<T>? Items { get; set; }

    /// <summary>
    /// Contains pagination details
    /// </summary>
    public PaginationResponseBase? Pagination { get; set; }

    /// <inheritdoc/>
    public string[]? Details { get; set; }
    #endregion
}