var builder = WebApplication.CreateBuilder(args);

OpenApiInfo info = new()
{
    Title = "Restaurant API documentation",
    Version = "v1",
    Description = "This page shows the API docuementation for restaurant management system powered by Lalo, you can use this project as template on future projects",
    Contact = new()
    {
        Name = "Developer",
        Email = "eduardrc5@gmail.com",
    },
    TermsOfService = new("https://localhost:7175/swagger")
};

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", info);

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("SqlConnection")!;

    options.UseSqlServer(connectionString, options =>
    {
        options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    });
});
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddMapsterBuilder();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapEndpoints();
app.Run();