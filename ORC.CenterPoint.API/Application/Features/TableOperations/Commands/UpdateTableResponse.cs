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
    #endregion
}