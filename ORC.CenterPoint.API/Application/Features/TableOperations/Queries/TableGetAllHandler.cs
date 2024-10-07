namespace ORC.CenterPoint.API.Application.Features.TableOperations.Queries;

public class TableGetAllHandler(ApplicationDbContext dbContext) : IRequestHandler<TableGetAllRequest, TableGetAllResponse>
{
    #region Fields
    private readonly ApplicationDbContext _dbContext = dbContext;
    #endregion

    public async Task<TableGetAllResponse> Handle(TableGetAllRequest request, CancellationToken cancellationToken)
    {
        IQueryable<RestaurantTable> tablesQuery = _dbContext.Tables.AsNoTracking();

        tablesQuery = tablesQuery.Skip(request.SkipRows).Take(request.RowsPerPage);

        List<RestaurantTable> tables = await tablesQuery.ToListAsync(cancellationToken);
        List<TableDto> tablesDto = tables.Adapt<List<TableDto>>();

        return new() { Tables = tablesDto };
    }
}