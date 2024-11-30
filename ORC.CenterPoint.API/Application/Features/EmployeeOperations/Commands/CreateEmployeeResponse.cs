namespace ORC.CenterPoint.API.Application.Features.EmployeeOperations.Commands;

public class CreateEmployeeResponse : OperationResponse<bool>
{
    #region Properties
    public required string Message { get; set; }

    public int Id { get; set; }
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
        Data = true,
        Id = request.Id,
        Message = $"Se registró el empleado '{request.FullName}'",
    };

    internal static CreateEmployeeResponse NotCreated() => new()
    {
        Message = "Empleado no registrada",
    };
    #endregion
}