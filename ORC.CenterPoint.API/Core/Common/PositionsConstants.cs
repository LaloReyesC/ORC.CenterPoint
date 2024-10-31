namespace ORC.CenterPoint.API.Core.Common;

public class PositionsConstants
{
    #region Constants
    public const short GeneralEmployeeId = 1;
    #endregion

    #region Properties
    public static EmployeePosition GeneralEmployee => new()
    {
        Id = GeneralEmployeeId,
        Name = "Empleado general",
        RegistrationDate = new DateTime(2024, 10, 30, 22, 43, 52, 152, DateTimeKind.Local).AddTicks(7041)
    };
    #endregion
}