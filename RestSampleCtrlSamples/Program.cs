using RestSample.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ProductDbContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
