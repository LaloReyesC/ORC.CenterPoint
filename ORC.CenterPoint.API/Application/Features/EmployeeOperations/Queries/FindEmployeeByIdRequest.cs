namespace ORC.CenterPoint.API.Application.Features.EmployeeOperations.Queries;

public class FindEmployeeByIdRequest(int id)
    : IRequest<FindEmployeeByIdResponse>
{
    #region Properties
    public int Id { get; set; } = id;
    #endregion
}