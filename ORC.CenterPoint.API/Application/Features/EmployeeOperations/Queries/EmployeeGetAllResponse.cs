namespace ORC.CenterPoint.API.Application.Features.EmployeeOperations.Queries;

public class EmployeeGetAllResponse
{
    #region Properties
    public required IReadOnlyList<EmployeeDto> Employees { get; set; }
    #endregion
}