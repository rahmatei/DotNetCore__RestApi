using Microsoft.AspNetCore.Http.Json;
using RestSample.Model;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(option =>
{
    option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
}).AddXmlDataContractSerializerFormatters().AddMvcOptions(options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.ReturnHttpNotAcceptable = true;
});

//builder.Services.AddControllers(options =>
//{
//    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
//});
builder.Services.AddDbContext<ProductDbContext>();
var app = builder.Build();

app.MapControllers();

app.Run();
