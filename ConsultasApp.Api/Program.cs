using ConsultasApp.Domain.Extensions;
using ConsultasApp.Infra.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

//caixa baixa nas rotas
builder.Services.AddRouting(options => options.LowercaseUrls = true);


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDomainServices();
builder.Services.AddEntityFramework(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
