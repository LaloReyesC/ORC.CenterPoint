namespace ORC.CenterPoint.API.Routers;

public class TableRoute : EndpointGroupBase
{
    #region Fields
    private readonly Type[] _handledExceptions = [typeof(NotFoundException), typeof(ApplicationException)];
    #endregion

    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(Get)
            .MapGet(Find, "{id}")
            .MapPost(Post)
            .MapPut(Put, "{id}")
            .MapDelete(Delete, "{id}");
    }

    public async Task<IResult> Get(IMediator mediator)
    {
        TableGetAllResponse response = await mediator.Send(new TableGetAllRequest());

        return Results.Ok(response);
    }

    public async Task<IResult> Find(IMediator mediator, int id)
    {
        FindTableByIdRequest request = new(id);
        FindTableByIdResponse response = await mediator.Send(request);

        return response.Table is not null ? Results.Ok(response) : Results.NotFound(response);
    }

    public async Task<IResult> Post(IMediator mediator, CreateTableRequest request)
    {
        CreateTableResponse response = CreateTableResponse.New;

        try
        {
            response = await mediator.Send(request);

            return Results.CreatedAtRoute("Find", new { id = response.Id }, response);
        }
        catch (Exception ex)
        {
            bool isCustomException = _handledExceptions.Contains(ex.GetType());

            response.Message = isCustomException ? ex.Message : "Ocurrió un error desconocido al actualizar la mesa";

            return Results.BadRequest(response);
        }
    }

    public async Task<IResult> Put(IMediator mediator, int id, UpdateTableRequest request)
    {
        UpdateTableResponse response = UpdateTableResponse.New;

        try
        {
            if (id == default)
            {
                throw new ApplicationException("El identificador especificado es inválido");
            }

            request.Id = id;
            response = await mediator.Send(request);

            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            bool isCustomException = _handledExceptions.Contains(ex.GetType());

            response.Message = isCustomException ? ex.Message : "Ocurrió un error desconocido al actualizar la mesa";

            return Results.BadRequest(response);
        }
    }

    public Task<IResult> Delete(IMediator mediator, int id)
    {
        throw new NotImplementedException("Not implemented endpoint yet");
    }
}