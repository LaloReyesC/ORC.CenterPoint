namespace ORC.CenterPoint.API.Application.Features.TableOperations.Queries;

public class FindTableByIdHandler(ApplicationDbContext dbContext) : IRequestHandler<FindTableByIdRequest, FindTableByIdResponse>
{
    #region Fields
    private readonly ApplicationDbContext _dbContext = dbContext;
    #endregion

    public async Task<FindTableByIdResponse> Handle(FindTableByIdRequest request, CancellationToken cancellationToken)
    {
        IQueryable<RestaurantTable> tablesQuery = _dbContext.Tables.AsNoTracking();

        RestaurantTable? table = await tablesQuery.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        TableDto? tableDto = table?.Adapt<TableDto>();

        return new() { Table = table };
    }
}