using FirstAPi.Infraestructure;
using FirstAPi.RequestPipeline;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
    builder => builder
        .WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod());
});
builder.Services.AddSwaggerGen();
builder.Services.AddInfraestructure(builder.Configuration);


var app = builder.Build();
app.InitializeDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API V1");
    });

    app.UseCors("AllowSpecificOrigin");
    app.UseRouting();
    _ = app.UseEndpoints(endpoints =>
    {
        _ = endpoints.MapControllers();
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();