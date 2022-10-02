using Core.Configuration;
using IoC;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.Configure<AppConfig>(builder.Configuration.GetSection("AppConfig"));
    builder.Services.AddDbContexts(builder.Configuration);
    builder.Services.AddRepositories();
    builder.Services.AddServices();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
{
    app.ConfigureExceptionHandler();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors(configure =>
    {
        configure
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });

    app.InitDatabase();

    app.MapControllers();

    app.Run();
}
