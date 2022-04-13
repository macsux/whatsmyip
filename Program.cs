var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/",  (ctx) =>
{
    return ctx.Response.WriteAsync(ctx.Connection.RemoteIpAddress.ToString());
});

app.Run();