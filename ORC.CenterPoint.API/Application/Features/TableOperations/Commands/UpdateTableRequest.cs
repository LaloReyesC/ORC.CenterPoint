namespace ORC.CenterPoint.API.Application.Features.TableOperations.Commands;

public class UpdateTableRequest : IRequest<UpdateTableResponse>
{
    #region Properties
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string RoomName { get; set; }

    public int AllowedDinersNumber { get; set; }
    #endregion
}