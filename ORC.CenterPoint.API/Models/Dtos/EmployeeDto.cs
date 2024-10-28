namespace ORC.CenterPoint.API.Models.Dtos;

public class EmployeeDto
{
    #region Properties
    /// <summary>
    /// Employee identifier on system
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// Contains employee status identifier
    /// </summary>
    public short StatusId { get; set; }

    /// <summary>
    /// Readonly property: Contains employee full name
    /// </summary>
    public string FullName => $"{Name} {LastName} {MaternalSurname}";

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

    /// <summary>
    /// Employee registration date on database
    /// </summary>
    public DateTime EmployeeRegistrationDate { get; set; }

    /// <summary>
    /// Contains status name
    /// </summary>
    public required string StatusName { get; set; }

    /// <summary>
    /// Entry registration date
    /// </summary>
    public DateTime StatusRegistrationDate { get; set; }
    #endregion
}