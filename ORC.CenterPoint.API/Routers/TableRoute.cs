namespace ORC.CenterPoint.API.Routers;

public class TableRoute
    : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
           .MapGet(GetTables)
           .MapGet(FindTableById, "{id}")
           .MapPost(CreateTable)
           .MapPut(UpdateTable, "{id}")
           .MapDelete(DeleteTable, "{id}");
    }

    /// <summary>
    /// Search all tables on system
    /// </summary>
    /// <param name="mediator">Service provider thah allow handling request</param>
    /// <param name="request">Contains request information</param>
    /// <returns>Returns an objetc of type <see cref="TableGetAllResponse"/> that contains all tables information</returns>
    /// <remarks>
    /// You should use this endpoint when you need retrieve all tables registred on system. Endpoint supports pagination
    /// so you can set the desired page and the items number per page that you need.
    /// </remarks>
    [ProducesResponseType(typeof(TableGetAllResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(TableGetAllResponse), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetTables(IMediator mediator, [AsParameters] TableGetAllRequest request)
    {
        TableGetAllResponse response = await mediator.Send(request);

        return SetResponse(response);
    }

    /// <summary>
    /// Search a table by identifier
    /// </summary>
    /// <param name="mediator">Request service provider processor</param>
    /// <param name="id">Table identifier</param>
    /// <returns>Return a table founded on system, otherwise return empty information</returns>
    /// <remarks>Search a table by identifier, if table is founded return all table information, otherwise doesn't return anything</remarks>
    [ProducesResponseType(typeof(FindTableByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FindTableByIdResponse), StatusCodes.Status404NotFound)]
    public async Task<IResult> FindTableById(IMediator mediator, int id)
    {
        FindTableByIdRequest request = new(id);
        FindTableByIdResponse response = await mediator.Send(request);

        return response.Table is not null ?
            Results.Ok(response) :
            Results.NotFound(response);
    }

    /// <summary>
    /// Create a new table entry on system
    /// </summary>
    /// <param name="mediator">Request service provider processor</param>
    /// <param name="request">Contains table information</param>
    /// <returns>Returns new table information on system if created, otherwise return process error detail</returns>
    /// <remarks>
    /// Create a new table on system, verify if table already exists on room and return an error when table is already exists, otherwise new table is added on system
    /// </remarks>
    [ProducesResponseType(typeof(CreateTableResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CreateTableResponse), StatusCodes.Status400BadRequest)]
    public async Task<IResult> CreateTable(IMediator mediator, CreateTableRequest request)
    {
        CreateTableResponse response = await mediator.Send(request);

        return response.Created ?
            Results.CreatedAtRoute(nameof(FindTableById), new { id = response.Id }, response) :
            Results.BadRequest(response);
    }

    /// <summary>
    /// Update table information
    /// </summary>
    /// <param name="mediator">Request service provider processor</param>
    /// <param name="id">Table identifier</param>
    /// <param name="request">Contains table information for update</param>
    /// <returns>
    /// Return table update details, when update is success return table information on property object, otherwise return null information and error detail
    /// </returns>
    /// <remarks>
    /// Update a table on system, verify table exists seek by identifier and check if doesn't exists another table with same name on same room. 
    /// When update is success return table information on property object, otherwise return null information and error detail
    /// </remarks>
    [ProducesResponseType(typeof(UpdateTableResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UpdateTableResponse), StatusCodes.Status400BadRequest)]
    public async Task<IResult> UpdateTable(IMediator mediator, int id, UpdateTableRequest request)
    {
        request.Id = id;

        UpdateTableResponse response = await mediator.Send(request);

        return response.Updated ?
            Results.Ok(response) :
            Results.BadRequest(response);
    }

    /// <summary>
    /// Delete a table on system
    /// </summary>
    /// <param name="mediator">Request service provider processor</param>
    /// <param name="id">Table identifier</param>
    /// <returns>Return nothing when table was deleted, otherwise return error detail</returns>\
    /// <remarks>
    /// Delete a table on system seek by table's identifier, when table exists and is deleted doesn't return content information, otherwise returns error detail
    /// </remarks>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(DeleteTableResponse), StatusCodes.Status400BadRequest)]
    public async Task<IResult> DeleteTable(IMediator mediator, int id)
    {
        DeleteTableRequest request = new(id);
        DeleteTableResponse response = await mediator.Send(request);

        return response.Deleted ?
            Results.NoContent() :
            Results.BadRequest(response);
    }
}