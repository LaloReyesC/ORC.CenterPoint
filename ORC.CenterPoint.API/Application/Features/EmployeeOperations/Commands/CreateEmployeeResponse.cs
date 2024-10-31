namespace ORC.CenterPoint.API.Application.Features.EmployeeOperations.Commands;

public class CreateEmployeeResponse
{
    #region Properties
    public bool Created { get; set; }

    public required string Message { get; set; }

    public int Id { get; set; }

    public static CreateEmployeeResponse New => new() { Message = string.Empty };
    #endregion

    #region Operators
    public static implicit operator CreateEmployeeResponse(string message) => new()
    {
        Message = message,
    };
    #endregion

    #region Private members
    internal static CreateEmployeeResponse RecordCreated(Employee request) => new()
    {
        Created = true,
        Id = request.Id,
        Message = $"Se registró el empleado '{request.FullName}'",
    };

    internal static CreateEmployeeResponse NotCreated() => new()
    {
        Message = "Empleado no registrada",
    };
    #endregion
}