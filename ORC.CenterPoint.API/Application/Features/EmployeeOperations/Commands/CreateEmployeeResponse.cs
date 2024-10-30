namespace ORC.CenterPoint.API.Application.Features.EmployeeOperations.Commands;

public class CreateEmployeeResponse
{
    #region Properties
    public bool Created { get; set; }

    public required string Message { get; set; }

    public int Id { get; set; }

    public static CreateEmployeeResponse New => new() { Message = string.Empty };
    #endregion

    #region Private members
    internal static CreateEmployeeResponse AlreadyExists(CreateEmployeeRequest request) => new()
    {
        Message = $"El empleado '{request.Name} {request.LastName} {request.MaternalSurname}' ya se encuentra registrado",
    };
    #endregion
}