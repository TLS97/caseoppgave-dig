using Case.Api.Clients;
using Case.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOsloBysykkelService, OsloBysykkelService>();
builder.Services.AddHttpClient<IOsloBysykkelApiClient, OsloBysykkelApiClient>(client =>
{
    client.BaseAddress = new Uri(
        builder.Configuration["OsloBysykkelApi:Endpoint"]!);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();