namespace ORC.CenterPoint.API.Application.Features.TableOperations.Commands;

public class UpdateTableResponse
{
    #region Properties
    public bool Updated { get; set; }

    public required string Message { get; set; }

    public RestaurantTable? TableDetails { get; set; }

    public static UpdateTableResponse New => new()
    {
        Message = string.Empty
    };

    public static UpdateTableResponse NotFound => new()
    {
        Message = "Mesa seleccionada inválida, no encontrada en el sistema"
    };
    #endregion

    #region Private members
    public static UpdateTableResponse AlreadyExists(UpdateTableRequest request) => new()
    {
        Message = $"Ya existe una mesa con el nombre '{request.Name}' en el área '{request.RoomName}'"
    };
    #endregion
}