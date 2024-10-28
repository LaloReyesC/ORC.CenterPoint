namespace ORC.CenterPoint.API.Application.Features.TableOperations.Queries;

public class TableGetAllRequest
    : IRequest<TableGetAllResponse>
{
    #region Properties
    /// <summary>
    /// Contains de desired page on pagination
    /// </summary>
    /// <example>1</example>
    [DefaultValue(1)]
    public int DesiredPage { get; set; }

    /// <summary>
    /// Indicates the rows per page that you need on seek
    /// </summary>
    /// <example>10</example>
    [DefaultValue(10)]
    public int RowsPerPage { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public int SkipRows => (DesiredPage - 1) * RowsPerPage;
    #endregion
}