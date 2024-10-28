namespace ORC.CenterPoint.API.Models.Entities;

public class RestaurantTable
{
    #region Properties
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string RoomName { get; set; }

    public int AllowedDinersNumber { get; set; }

    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    #endregion
}