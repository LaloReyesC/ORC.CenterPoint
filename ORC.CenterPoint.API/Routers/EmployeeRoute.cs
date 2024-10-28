namespace ORC.CenterPoint.API.Routers;

public class EmployeeRoute
    : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
           .MapGet(Get);
    }

    public async Task<IResult> Get(IMediator mediator, [AsParameters] EmployeeGetAllRequest request)
    {
        EmployeeGetAllResponse response = await mediator.Send(request);

        return Results.Ok(response);
    }
}