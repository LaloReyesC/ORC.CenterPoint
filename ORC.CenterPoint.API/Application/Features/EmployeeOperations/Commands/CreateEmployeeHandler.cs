namespace ORC.CenterPoint.API.Application.Features.EmployeeOperations.Commands;

public class CreateEmployeeHandler(ApplicationDbContext dbContext)
    : IRequestHandler<CreateEmployeeRequest, CreateEmployeeResponse>
{
    #region Fields
    private readonly ApplicationDbContext _dbContext = dbContext;
    #endregion

    public async Task<CreateEmployeeResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        bool employeeAlreadyExists = await _dbContext.Employees.AsNoTracking()
            .AnyAsync(table =>
                table.Name == request.Name &&
                table.LastName == request.LastName &&
                table.MaternalSurname == request.MaternalSurname,
            cancellationToken);

        if (employeeAlreadyExists)
        {
            return CreateEmployeeResponse.AlreadyExists(request);
        }

        Employee employee = request.Adapt<Employee>();

        employee.StatusId = StatusConstants.ActiveId;

        await _dbContext.Employees.AddAsync(employee, cancellationToken);

        int affectedRows = await _dbContext.SaveChangesAsync(cancellationToken);
        bool created = affectedRows > 0;

        CreateEmployeeResponse response = new()
        {
            Created = created,
            Id = employee.Id,
            Message = created ?
                $"Se registró el empleado '{request.Name} {request.LastName} {request.MaternalSurname}'" :
                "Empleado no registrada",
        };

        return response;
    }
}