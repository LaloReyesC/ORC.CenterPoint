namespace ORC.CenterPoint.API.Application.Features.Common.Commands;

public class OperationResponse<T>
    : IResponse
{
    #region Properties
    /// <summary>
    /// Contains operation State code
    /// </summary>
    public OperationStateEnum StateCode { get; set; }

    /// <summary>
    /// Contains operation state description
    /// </summary>
    public string State => StateCode.ToString();

    /// <summary>
    /// Contains operation result data
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Contains process details if query require send process messages
    /// </summary>
    public string[]? Details { get; set; }
    #endregion
}