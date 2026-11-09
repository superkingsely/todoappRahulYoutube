

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration)
                .AddApplication();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/openapi/v1.json", "Todo API V1");
    c.RoutePrefix = "swagger";
});
// app.UseHttpsRedirection();

app.MapControllers();
app.Run();


