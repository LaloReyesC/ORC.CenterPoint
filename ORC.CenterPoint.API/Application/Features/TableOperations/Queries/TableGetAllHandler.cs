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
        IQueryable<RestaurantTable> tablesQuery = _dbContext.Tables
            .AsNoTracking()
            .OrderByDescending(table => table.RegistrationDate);

        tablesQuery = tablesQuery
            .Skip(request.SkipRows)
            .Take(request.RowsPerPage);

        List<RestaurantTable> tables = await tablesQuery.ToListAsync(cancellationToken);
        List<TableDto> tablesDto = tables.Adapt<List<TableDto>>();

        return new() { Tables = tablesDto };
    }
}