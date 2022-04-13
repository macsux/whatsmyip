var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/",  (ctx) =>
{
    var callerIp = ctx.Connection.RemoteIpAddress.ToString();
    if (ctx.Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedFor))
    {
        callerIp = forwardedFor.ToString();
    }
    return ctx.Response.WriteAsync(callerIp);
});

app.Run();