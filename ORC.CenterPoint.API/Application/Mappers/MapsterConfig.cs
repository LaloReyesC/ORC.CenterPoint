namespace ORC.CenterPoint.API.Application.Mappers;

/// <summary>
/// Clase que contiene las configuraciones para mapeo de objetos
/// </summary>
public static class MapsterConfig
{
    /// <summary>
    /// Agrega las configuraciones de mapping con Mapster
    /// </summary>
    /// <param name="services">Colección de servicios</param>
    /// <returns>Retorna la colección de servicios con las dependencias integradas</returns>
    public static IServiceCollection AddMapsterBuilder(this IServiceCollection services)
    {
        #region Employee -> EmployeeDto
        TypeAdapterConfig<Employee, EmployeeDto>.NewConfig()
            .Map(dest => dest.EmployeeId, src => src.Id)
            .Map(dest => dest.EmployeeRegistrationDate, src => src.RegistrationDate)
            .Map(dest => dest.StatusName, src => src.Status.Name)
            .Map(dest => dest.StatusRegistrationDate, src => src.Status.RegistrationDate);
        #endregion

        TypeAdapterConfig<CreateEmployeeRequest, Employee>.NewConfig()
            .Map(dest => dest.Number, src => src.EmployeeNumber);

        return services;
    }
}