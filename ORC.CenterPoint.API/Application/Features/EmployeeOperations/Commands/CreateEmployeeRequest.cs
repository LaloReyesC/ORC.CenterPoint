namespace ORC.CenterPoint.API.Application.Features.EmployeeOperations.Commands;

public class CreateEmployeeRequest
    : IRequest<CreateEmployeeResponse>
{
    #region Properties
    /// <summary>
    /// Contains employee name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Contains employee lastname
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Optional: Contains employee maternal surname
    /// </summary>
    public string? MaternalSurname { get; set; }

    /// <summary>
    /// Contains employee born date
    /// </summary>
    public DateTime BornDate { get; set; }
    #endregion
}