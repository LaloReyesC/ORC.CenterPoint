namespace ORC.CenterPoint.API.Application.Features.TableOperations.Commands;

public class DeleteTableHandler(ApplicationDbContext dbContext)
    : IRequestHandler<DeleteTableRequest, DeleteTableResponse>
{
    #region Fields
    private readonly ApplicationDbContext _dbContext = dbContext;
    #endregion

    public async Task<DeleteTableResponse> Handle(DeleteTableRequest request, CancellationToken cancellationToken)
    {
        DeleteTableResponse response = DeleteTableResponse.New;

        RestaurantTable? table = await _dbContext.Tables.FindAsync(request.Id, cancellationToken);

        if (table is null)
        {
            return DeleteTableResponse.NotFound;
        }

        _dbContext.Tables.Remove(table);

        int affectedRows = await _dbContext.SaveChangesAsync(cancellationToken);

        bool deleted = affectedRows > 0;

        response.Deleted = deleted;
        response.Message = deleted ? string.Empty :
            "No fue posible eliminar la mesa especificada, intentelo nuevamente";

        return response;
    }
}