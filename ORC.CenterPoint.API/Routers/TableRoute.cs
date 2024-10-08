namespace ORC.CenterPoint.API.Routers;

public class TableRoute : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(Get)
            .MapGet(Find, "{id}")
            .MapPost(Post);
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
        CreateTableResponse response = await mediator.Send(request);

        return Results.CreatedAtRoute("Find", new { id = response.Id }, response);
    }
}