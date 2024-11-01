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

    [ProducesResponseType(typeof(EmployeeGetAllResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(EmployeeGetAllResponse), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetEmployees(IMediator mediator, [AsParameters] EmployeeGetAllRequest request)
    {
        EmployeeGetAllResponse response = await mediator.Send(request);

        return response.Employees.Any() ?
            Results.Ok(response) :
            Results.NotFound(response);
    }

    [ProducesResponseType(typeof(FindEmployeeByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FindEmployeeByIdResponse), StatusCodes.Status404NotFound)]
    public async Task<IResult> FindEmployeeById(IMediator mediator, int id)
    {
        FindEmployeeByIdRequest request = new(id);

        FindEmployeeByIdResponse response = await mediator.Send(request);

        return response.Record is not null ?
            Results.Ok(response) :
            Results.NotFound(response);
    }

    [ProducesResponseType(typeof(CreateEmployeeResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CreateEmployeeResponse), StatusCodes.Status400BadRequest)]
    public async Task<IResult> CreateEmployee(IMediator mediator, CreateEmployeeRequest request)
    {
        CreateEmployeeResponse response = await mediator.Send(request);

        return response.Created ?
            Results.CreatedAtRoute(nameof(FindEmployeeById), new { id = response.Id }, response) :
            Results.BadRequest(response);
    }
}