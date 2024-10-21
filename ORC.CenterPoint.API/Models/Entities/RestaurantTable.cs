namespace ORC.CenterPoint.API.Models.Entities;

[Table("RestaurantTable")]
[Index("Name", Name = "IX_RestaurantTable_Name")]
[Index("RoomName", Name = "IX_RestaurantTable_RoomName")]
public class RestaurantTable
{
    #region Properties
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required]
    [StringLength(100)]
    public required string RoomName { get; set; }

    [Required]
    public int AllowedDinersNumber { get; set; }

    [Required]
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    #endregion
}