namespace ORC.CenterPoint.API.Core.Common;

public class StatusConstants
{
    #region Constants
    public const short ActiveId = 1;
    public const short DisabledId = 2;
    public const short LeaveId = 3;
    public const short RejoinId = 4;
    public const short VacationsId = 5;
    public const short DeletedId = 9999;
    #endregion

    #region Properties
    public static Status Active => new()
    {
        Id = ActiveId,
        Name = "Activo",
        RegistrationDate = new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7041)
    };

    public static Status Disabled => new()
    {
        Id = DisabledId,
        Name = "Deshabilitado",
        RegistrationDate = new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7053)
    };

    public static Status Leave => new()
    {
        Id = LeaveId,
        Name = "Baja",
        RegistrationDate = new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7055)
    };

    public static Status Rejoin => new()
    {
        Id = RejoinId,
        Name = "Reincorporado",
        RegistrationDate = new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7056)
    };

    public static Status Vacations => new()
    {
        Id = VacationsId,
        Name = "De vacaciones",
        RegistrationDate = new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7057)
    };

    public static Status Deleted => new()
    {
        Id = DeletedId,
        Name = "Eliminado",
        RegistrationDate = new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7058)
    };
    #endregion
}