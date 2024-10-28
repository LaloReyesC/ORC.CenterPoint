namespace ORC.CenterPoint.API.Models.Dtos;

/// <summary>
/// Contains table information
/// </summary>
public class TableDto
{
    #region Properties
    /// <summary>
    /// Table unique identifier
    /// </summary>
    /// <example>1133</example>
    public int Id { get; set; }

    /// <summary>
    /// Represents table name
    /// </summary>
    /// <example>Mesa 01</example>
    public required string Name { get; set; }

    /// <summary>
    /// Indicates table's room name
    /// </summary>
    /// <example>Salon 01</example>
    public required string RoomName { get; set; }

    /// <summary>
    /// Indicates max dinners number on the table
    /// </summary>
    /// <example>6</example>
    public int AllowedDinersNumber { get; set; }
    #endregion
}