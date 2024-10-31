namespace ORC.CenterPoint.API.Models.Entities;

public class EmployeePosition
{
    #region Properties
    public short Id { get; set; }

    public required string Name { get; set; }

    public DateTime RegistrationDate { get; set; }

    public IList<Employee> Employees { get; set; } = [];
    #endregion
}