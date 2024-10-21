namespace ORC.CenterPoint.API.Application.Features.TableOperations.Commands;

public class DeleteTableRequest(int id)
    : IRequest<DeleteTableResponse>
{
    #region Properties
    public int Id { get; set; } = id;
    #endregion
}