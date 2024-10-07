namespace ORC.CenterPoint.API.Models.Dtos;

public class TableDto
{
    #region Properties
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string RoomName { get; set; }

    public int AllowedDinersNumber { get; set; }
    #endregion
}