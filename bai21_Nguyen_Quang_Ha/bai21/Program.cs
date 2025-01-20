var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = "swagger"; // Đặt Swagger UI ở /swagger
    });
}

app.UseHttpsRedirection();

// Điều hướng mặc định tới bai21.html khi truy cập "/"
app.MapGet("/", async context =>
{
    await context.Response.SendFileAsync("bai21.html");
});

// Middleware xử lý API
app.UseAuthorization();
app.MapControllers();

app.Run();
