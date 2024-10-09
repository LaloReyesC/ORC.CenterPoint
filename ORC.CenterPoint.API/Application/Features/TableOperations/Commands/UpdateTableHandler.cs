namespace ORC.CenterPoint.API.Application.Features.TableOperations.Commands;

public class UpdateTableHandler(ApplicationDbContext dbContext)
    : IRequestHandler<UpdateTableRequest, UpdateTableResponse>
{
    #region Fields
    private readonly ApplicationDbContext _dbContext = dbContext;
    #endregion

    public async Task<UpdateTableResponse> Handle(UpdateTableRequest request, CancellationToken cancellationToken)
    {
        UpdateTableResponse response = UpdateTableResponse.New;

        RestaurantTable table = await _dbContext.Tables.FindAsync(request.Id, cancellationToken) ??
            throw new NotFoundException("Mesa seleccionada inválida, no encontrada en el sistema");

        bool existTable = await _dbContext.Tables.AsNoTracking()
            .AnyAsync(table => table.Name == request.Name && table.RoomName == request.RoomName && table.Id != request.Id, cancellationToken);

        if (existTable)
        {
            throw new ApplicationException($"Ya existe una mesa con el nombre '{request.Name}' en el área '{request.RoomName}'");
        }

        table.AllowedDinersNumber = request.AllowedDinersNumber;
        table.Name = request.Name;
        table.RoomName = request.RoomName;

        int affectedRows = await _dbContext.SaveChangesAsync(cancellationToken);

        bool updated = affectedRows > 0;

        response.Updated = updated;
        response.TableDetails = table;
        response.Message = updated ? "Se ha actualizado correctamente la información de la mesa" :
            "No se detectarón cambios en la información de la mesa";

        return response;
    }
}