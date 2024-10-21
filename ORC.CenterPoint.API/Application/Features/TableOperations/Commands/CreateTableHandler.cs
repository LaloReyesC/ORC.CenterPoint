namespace ORC.CenterPoint.API.Application.Features.TableOperations.Commands;

public class CreateTableHandler(ApplicationDbContext dbContext)
    : IRequestHandler<CreateTableRequest, CreateTableResponse>
{
    #region Fields
    private readonly ApplicationDbContext _dbContext = dbContext;
    #endregion

    public async Task<CreateTableResponse> Handle(CreateTableRequest request, CancellationToken cancellationToken)
    {
        bool existTable = await _dbContext.Tables.AsNoTracking()
            .AnyAsync(table => table.Name == request.Name && table.RoomName == request.RoomName, cancellationToken);

        if (existTable)
        {
            return CreateTableResponse.TableAlreadyExists(request);
        }

        RestaurantTable table = request.Adapt<RestaurantTable>();

        await _dbContext.Tables.AddAsync(table, cancellationToken);

        int affectedRows = await _dbContext.SaveChangesAsync(cancellationToken);
        bool created = affectedRows > 0;

        CreateTableResponse response = new()
        {
            Created = created,
            Id = table.Id,
            Message = created ? $"Se ha registrado la mesa '{request.Name}'" : "Mesa no registrada",
        };

        return response;
    }
}