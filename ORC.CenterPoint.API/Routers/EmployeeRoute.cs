namespace ORC.CenterPoint.API.Routers;

public class EmployeeRoute
    : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
           .MapGet(GetEmployees)
           .MapGet(FindEmployeeById, "{id}")
           .MapPost(CreateEmployee);
    }

    public async Task<IResult> GetEmployees(IMediator mediator, [AsParameters] EmployeeGetAllRequest request)
    {
        EmployeeGetAllResponse response = await mediator.Send(request);

        return Results.Ok(response);
    }

    public async Task<IResult> FindEmployeeById(IMediator mediator, int id)
    {
        return await Task.FromResult(Results.Ok(new { Message = "Método no implementado" }));
    }

    public async Task<IResult> CreateEmployee(IMediator mediator, CreateEmployeeRequest request)
    {
        CreateEmployeeResponse response = await mediator.Send(request);

        return response.Created ?
            Results.CreatedAtRoute(nameof(FindEmployeeById), new { id = response.Id }, response) :
            Results.BadRequest(response);
    }
}