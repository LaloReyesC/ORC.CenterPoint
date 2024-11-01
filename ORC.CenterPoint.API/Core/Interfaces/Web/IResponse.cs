namespace ORC.CenterPoint.API.Core.Interfaces.Web;

public interface IResponse
{
    #region Properties
    /// <summary>
    /// Contains operation State code
    /// </summary>
    OperationStateEnum StateCode { get; set; }

    /// <summary>
    /// Contains operation state description
    /// </summary>
    string State { get; }

    /// <summary>
    /// Contains process details if query require send process messages
    /// </summary>
    string[]? Details { get; set; }
    #endregion
}