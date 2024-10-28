namespace ORC.CenterPoint.API.Application.Features.EmployeeOperations.Queries;

public class EmployeeGetAllHandler(ApplicationDbContext dbContext)
    : IRequestHandler<EmployeeGetAllRequest, EmployeeGetAllResponse>
{
    #region Fields
    private readonly ApplicationDbContext _dbContext = dbContext;
    #endregion

    public async Task<EmployeeGetAllResponse> Handle(EmployeeGetAllRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Employee> query = _dbContext.Employees
            .AsNoTracking()
            .OrderByDescending(e => e.Id)
            .Include(p => p.Status);

        query = QueryFilter(query, request);
        query = query
            .Skip(request.SkipRows)
            .Take(request.RowsPerPage);

        List<Employee> employees = await query.ToListAsync(cancellationToken);

        IEnumerable<EmployeeDto> employeesResponse = employees.Select(employee => new EmployeeDto()
        {
            BornDate = employee.BornDate,
            EmployeeId = employee.Id,
            LastName = employee.LastName,
            MaternalSurname = employee.MaternalSurname,
            Name = employee.Name,
            EmployeeRegistrationDate = employee.RegistrationDate,
            StatusId = employee.StatusId,
            StatusName = employee.Status.Name,
            StatusRegistrationDate = employee.Status.RegistrationDate,
        });

        return new EmployeeGetAllResponse() { Employees = employeesResponse.ToList() };
    }

    #region Private members
    static IQueryable<Employee> QueryFilter(IQueryable<Employee> employeeQuery, EmployeeGetAllRequest request)
    {
        if (request.StatusId.HasValue)
        {
            employeeQuery = employeeQuery.Where(e => e.StatusId == request.StatusId);
        }

        if (!request.EmployeeName.IsNullOrEmpty())
        {
            employeeQuery = employeeQuery.Where(e =>
                e.Name.StartsWith(request.EmployeeName!) ||
                e.LastName.StartsWith(request.EmployeeName!));
        }

        if (request.From.HasValue && request.Until.HasValue)
        {
            employeeQuery = employeeQuery.Where(e =>
                e.RegistrationDate >= request.From &&
                e.RegistrationDate <= request.Until);
        }

        return employeeQuery;
    }
    #endregion
}