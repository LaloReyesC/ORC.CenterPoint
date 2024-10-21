namespace ORC.CenterPoint.API.Application.Features.TableOperations.Commands;

public class DeleteTableResponse
{
    #region Properties
    public bool Deleted { get; set; }

    public string? Message { get; set; }

    public static DeleteTableResponse New => new();

    public static DeleteTableResponse NotFound => new() { Message = "Mesa no encontrada en el sistema" };
    #endregion
}