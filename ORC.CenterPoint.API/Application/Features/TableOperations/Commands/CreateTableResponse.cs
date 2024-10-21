namespace ORC.CenterPoint.API.Application.Features.TableOperations.Commands;

public class CreateTableResponse
{
    #region Properties
    public bool Created { get; set; }

    public required string Message { get; set; }

    public int Id { get; set; }

    public static CreateTableResponse New => new() { Message = string.Empty };
    #endregion

    #region Private members
    public static CreateTableResponse TableAlreadyExists(CreateTableRequest request) => new()
    {
        Message = $"Ya existe una mesa con el nombre '{request.Name}' en el área '{request.RoomName}'",
    };
    #endregion
}