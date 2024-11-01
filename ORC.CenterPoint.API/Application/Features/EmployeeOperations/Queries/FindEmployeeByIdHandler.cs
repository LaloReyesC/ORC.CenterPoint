namespace ORC.CenterPoint.API.Application.Features.EmployeeOperations.Queries;

public class FindEmployeeByIdHandler(ApplicationDbContext dbContext)
    : IRequestHandler<FindEmployeeByIdRequest, FindEmployeeByIdResponse>
{
    #region Fields
    private readonly ApplicationDbContext _dbContext = dbContext;
    #endregion

    public async Task<FindEmployeeByIdResponse> Handle(FindEmployeeByIdRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Employee> query = _dbContext.Employees
            .AsNoTracking()
            .Include(employee => employee.Status)
            .Include(employee => employee.Position);

        Employee? employee = await query.FirstOrDefaultAsync(employee => employee.Id == request.Id, cancellationToken);
        EmployeeDto? employeeDto = employee?.Adapt<EmployeeDto>();

        return new() { Record = employeeDto };
    }
}