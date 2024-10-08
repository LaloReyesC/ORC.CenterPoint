namespace ORC.CenterPoint.API.Application.Features.TableOperations.Commands;

public class CreateTableRequest : IRequest<CreateTableResponse>
{
    #region Properties
    public required string Name { get; set; }

    public required string RoomName { get; set; }

    public int AllowedDinersNumber { get; set; }
    #endregion
}