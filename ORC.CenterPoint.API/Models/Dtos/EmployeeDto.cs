namespace ORC.CenterPoint.API.Models.Dtos;

public class EmployeeDto
{
    #region Properties
    /// <summary>
    /// Employee identifier on system
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// Contains employee number identifier
    /// </summary>
    public required string EmployeeNumber { get; set; }

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
    /// Contains employee full name
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Contains employee born date
    /// </summary>
    public DateTime BornDate { get; set; }

    /// <summary>
    /// Employee registration date on database
    /// </summary>
    public DateTime EmployeeRegistrationDate { get; set; }

    /// <summary>
    /// Contains employee status identifier
    /// </summary>
    public short StatusId { get; set; }

    /// <summary>
    /// Contains status name
    /// </summary>
    public required string StatusName { get; set; }

    /// <summary>
    /// Contains employee position identifier
    /// </summary>
    public short PositionId { get; set; }

    /// <summary>
    /// Contains employee position
    /// </summary>
    public required string PositionName { get; set; }
    #endregion
}