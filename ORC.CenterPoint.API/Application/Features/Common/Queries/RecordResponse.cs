namespace ORC.CenterPoint.API.Application.Features.Common.Queries;

public class RecordResponse<T>
    where T : class
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
    /// Contains record information if seeks return it, otherwise, return default value
    /// </summary>
    public T? Record { get; set; }

    /// <summary>
    /// Contains process details if query require send process messages
    /// </summary>
    public string[]? Details { get; set; }
    #endregion
}