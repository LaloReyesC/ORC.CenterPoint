namespace ORC.CenterPoint.API.Application.Features.TableOperations.Queries;

public class TableGetAllRequest : IRequest<TableGetAllResponse>
{
    #region Properties
    public int DesiredPage { get; set; } = 1;

    public int RowsPerPage { get; set; } = 10;

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public int SkipRows => (DesiredPage - 1) * RowsPerPage;
    #endregion
}