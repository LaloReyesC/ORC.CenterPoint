namespace ORC.CenterPoint.API.Application.Features.TableOperations.Queries;

public class TableGetAllHandler(ApplicationDbContext dbContext)
    : IRequestHandler<TableGetAllRequest, TableGetAllResponse>
{
    #region Fields
    private readonly ApplicationDbContext _dbContext = dbContext;
    #endregion

    public async Task<TableGetAllResponse> Handle(TableGetAllRequest request, CancellationToken cancellationToken)
    {
        //Sino ponemos el Order By en este punto, el query generado por EF genera una subconsulta y
        //genera un Order By por nosotros que puede alentar el proceso eventualmente
        IQueryable<RestaurantTable> query = _dbContext.Tables
            .AsNoTracking()
            .OrderByDescending(table => table.RegistrationDate);

        long totalItems = await query.LongCountAsync(cancellationToken);

        query = query
            .Skip(request.SkipRows)
            .Take(request.RowsPerPage);

        List<RestaurantTable> tables = await query.ToListAsync(cancellationToken);
        List<TableDto> tablesDto = tables.Adapt<List<TableDto>>();

        PaginationResponseBase pagination = request.Adapt<PaginationResponseBase>();

        pagination.TotalItems = totalItems;

        return new()
        {
            Items = tablesDto,
            StateCode = OperationStateEnum.Ok,
            Pagination = pagination,
        };
    }
}