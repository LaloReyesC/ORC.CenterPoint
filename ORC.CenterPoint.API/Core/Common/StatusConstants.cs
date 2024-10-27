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
    public static Status Active => new() { Id = ActiveId, Name = "Activo" };
    public static Status Disabled => new() { Id = DisabledId, Name = "Deshabilitado" };
    public static Status Leave => new() { Id = LeaveId, Name = "Baja" };
    public static Status Rejoin => new() { Id = RejoinId, Name = "Reincorporado" };
    public static Status Vacations => new() { Id = VacationsId, Name = "De vacaciones" };
    public static Status Deleted => new() { Id = DeletedId, Name = "Eliminado" };
    #endregion
}