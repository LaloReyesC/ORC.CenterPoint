namespace ORC.CenterPoint.API.Application.Features.TableOperations.Commands;

public class CreateTableResponse
{
    #region Properties
    public bool Created { get; set; }

    public required string Message { get; set; }

    public int Id { get; set; }

    public static CreateTableResponse New => new() { Message = string.Empty };
    #endregion
}