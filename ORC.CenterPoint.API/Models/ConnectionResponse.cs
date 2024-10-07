namespace ORC.CenterPoint.API.Models;

/// <summary>
/// Respuesta para prueba de conexión del API
/// </summary>
public class ConnectionResponse
{
    #region Properties
    /// <summary>
    /// Mensaje de prueba para comprobar que el servicio responde adecuadamente
    /// </summary>
    public required string Message { get; set; }
    #endregion
}