namespace ORC.CenterPoint.API.Routers;

public class TableRoute : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet("/", Get)
            .WithName("Tables");
    }

    public async Task<IResult> Get(IMediator mediator)
    {
        TableGetAllResponse response = await mediator.Send(new TableGetAllRequest());

        return Results.Ok(response);
    }
}