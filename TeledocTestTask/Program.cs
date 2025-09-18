using TeledocTestTask.Application.DI;
using TeledocTestTask.Infrastructure.DI;
using TeledocTestTask.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    string fullPath = Path.Combine(AppContext.BaseDirectory, "TeledocTestTask.xml");
    options.IncludeXmlComments(fullPath);
});

builder.Services.AddMediatr();
builder.Services.AddFluentValidation();

builder.Services.AddDBContext(builder.Configuration.GetConnectionString("Database"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
