namespace ORC.CenterPoint.API.Infraestructure;

public abstract class EndpointGroupBase
{
    #region Properties
    private static Dictionary<OperationStateEnum, Func<dynamic, IResult>> OpertionResult => new()
    {
        { OperationStateEnum.BadRequest, (response) => Results.BadRequest(response) },
        { OperationStateEnum.Created, (response) => Results.CreatedAtRoute(response) },
        { OperationStateEnum.InternalServerError, (response) => Results.BadRequest(response) },
        { OperationStateEnum.NoContent, (_) => Results.NoContent() },
        { OperationStateEnum.NotFound, (response) => Results.NotFound(response) },
        { OperationStateEnum.Ok, (response) => Results.Ok(response) },
        { OperationStateEnum.Unauthorized, (_) => Results.Unauthorized() },
        { OperationStateEnum.UnprocessableEntity, (response) => Results.UnprocessableEntity(response) },
    };
    #endregion

    /// <summary>
    /// Set response data and return object on response context
    /// </summary>
    /// <typeparam name="T">Response type, it shoult inheriths from <see cref="IResponse"/></typeparam>
    /// <param name="response">response object for request context</param>
    /// <param name="handlerOnCreated">Contains handler to redirect when a resource is created</param>
    /// <param name="contentOnCreated">Contains params when a resource is created</param>
    /// <returns>Return result from <see cref="IResult"/> implementations</returns>
    /// <exception cref="NotImplementedException">Throws exception when operation state is not implemented on responde dictionary</exception>
    public IResult SetResponse<T>(T response, Delegate? handlerOnCreated = null, object? contentOnCreated = null)
        where T : IResponse
    {
        if (!OpertionResult.TryGetValue(response.StateCode, out var processor))
        {
            throw new NotImplementedException($"No se ha encontrado la implementación para el tipo de respuesta '{response.State}'");
        }

        if (response.StateCode == OperationStateEnum.Created &&
            handlerOnCreated is not null &&
            contentOnCreated is not null)
        {
            return Results.CreatedAtRoute(nameof(handlerOnCreated), contentOnCreated, response);
        }
        else
        {
            response.StateCode = OperationStateEnum.Ok;
        }

        return processor(response);
    }

    public abstract void Map(WebApplication app);
}