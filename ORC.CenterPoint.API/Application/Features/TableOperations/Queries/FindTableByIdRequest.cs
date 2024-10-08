namespace ORC.CenterPoint.API.Application.Features.TableOperations.Queries;

public class FindTableByIdRequest(int id)
    : IRequest<FindTableByIdResponse>
{
    #region Properties
    public int Id { get; set; } = id;
    #endregion
}