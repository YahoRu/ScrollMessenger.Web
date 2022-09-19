namespace SecondTestApp.Web
{
    public class ShortestMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Query["token"];
            if (token != "!!!")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token isnt \"!!!\"");
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
}
