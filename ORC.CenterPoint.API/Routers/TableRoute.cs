namespace ORC.CenterPoint.API.Routers;

public class TableRoute
    : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        throw new NotImplementedException("Debes implementar binding para soportar el objeto desde queryString en el método de Get");

        app.MapGroup(this)
            .MapGet(Get)
            .MapGet(Find, "{id}")
            .MapPost(Post)
            .MapPut(Put, "{id}")
            .MapDelete(Delete, "{id}");
    }

    public async Task<IResult> Get(IMediator mediator, TableGetAllRequest request)
    {
        throw new NotImplementedException("Debes implementar binding para soportar el objeto desde queryString");

        TableGetAllResponse response = await mediator.Send(request);

        bool existsTables = response.Tables.Count > 0;

        return existsTables ? Results.Ok(response) : Results.NotFound(response);
    }

    public async Task<IResult> Find(IMediator mediator, int id)
    {
        FindTableByIdRequest request = new(id);
        FindTableByIdResponse response = await mediator.Send(request);

        return response.Table is not null ? Results.Ok(response) : Results.NotFound(response);
    }

    public async Task<IResult> Post(IMediator mediator, CreateTableRequest request)
    {
        CreateTableResponse response = await mediator.Send(request);

        return response.Created ?
            Results.CreatedAtRoute("Find", new { id = response.Id }, response) :
            Results.BadRequest(response);
    }

    public async Task<IResult> Put(IMediator mediator, int id, UpdateTableRequest request)
    {
        request.Id = id;

        UpdateTableResponse response = await mediator.Send(request);

        return response.Updated ?
            Results.Ok(response) :
            Results.BadRequest(response);
    }

    public async Task<IResult> Delete(IMediator mediator, int id)
    {
        DeleteTableRequest request = new(id);
        DeleteTableResponse response = await mediator.Send(request);

        return response.Deleted ?
            Results.NoContent() :
            Results.BadRequest(response);
    }
}