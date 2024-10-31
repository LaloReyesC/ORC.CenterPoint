namespace ORC.CenterPoint.API.Application.Features.EmployeeOperations.Commands;

public class CreateEmployeeRequest
    : IRequest<CreateEmployeeResponse>
{
    #region Properties
    /// <summary>
    /// Employee position Identifier
    /// </summary>
    /// <example>Chef</example>
    public short PositionId { get; set; }

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
    /// Readonly property: Contains employee full name
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public string FullName => $"{Name.Trim()} {LastName.Trim()} {MaternalSurname?.Trim()}";

    /// <summary>
    /// Contains employee number
    /// </summary>
    public required string EmployeeNumber { get; set; }

    /// <summary>
    /// Contains employee born date
    /// </summary>
    public DateTime BornDate { get; set; }
    #endregion
}