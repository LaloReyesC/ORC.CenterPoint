namespace ORC.CenterPoint.API.Application.Features.EmployeeOperations.Queries;

public class EmployeeGetAllRequest
    : PaginationRequestBase, IRequest<EmployeeGetAllResponse>
{
    #region Properties
    /// <summary>
    /// Contains employee status identifier
    /// </summary>
    public short? StatusId { get; set; }

    /// <summary>
    /// Contains employee name
    /// </summary>
    public string? EmployeeName { get; set; }

    /// <summary>
    /// Contains employee born date
    /// </summary>
    public DateTime? From { get; set; }

    /// <summary>
    /// Contains until
    /// </summary>
    public DateTime? Until { get; set; }
    #endregion
}