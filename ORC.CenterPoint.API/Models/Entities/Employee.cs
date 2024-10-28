namespace ORC.CenterPoint.API.Models.Entities;

public class Employee
{
    #region Properties
    /// <summary>
    /// Employee identifier on system
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Contains employee status identifier
    /// </summary>
    public short StatusId { get; set; }

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
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// Navigational property for status detail
    /// </summary>
    public required Status Status { get; set; }
    #endregion
}