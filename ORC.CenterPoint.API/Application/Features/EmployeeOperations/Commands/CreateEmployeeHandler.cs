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
            .AnyAsync(table => table.FullName == request.FullName, cancellationToken);

        if (employeeAlreadyExists)
        {
            return $"El empleado '{request.FullName}' ya se encuentra registrado";
        }

        employeeAlreadyExists = await _dbContext.Employees.AsNoTracking()
            .AnyAsync(table => table.Number == request.EmployeeNumber, cancellationToken);

        if (employeeAlreadyExists)
        {
            return $"Un empleado con el número '{request.EmployeeNumber}' ya se encuentra registrado";
        }

        employeeAlreadyExists = await _dbContext.EmployeePositions.AsNoTracking()
            .AnyAsync(table => table.Id == request.PositionId, cancellationToken);

        if (!employeeAlreadyExists)
        {
            return $"El puesto seleccionado para el empleado es inválido";
        }

        Employee employee = request.Adapt<Employee>();

        employee.StatusId = StatusConstants.ActiveId;

        await _dbContext.Employees.AddAsync(employee, cancellationToken);

        int affectedRows = await _dbContext.SaveChangesAsync(cancellationToken);
        bool created = affectedRows > 0;

        return created ?
            CreateEmployeeResponse.RecordCreated(employee) :
            CreateEmployeeResponse.NotCreated();
    }
}