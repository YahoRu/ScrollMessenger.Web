namespace SecondTestApp.Web
{
    public class MyOwnMdlw
    {
        private readonly RequestDelegate _Next;

        public MyOwnMdlw(RequestDelegate next)
        {
            _Next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if(token != "!!!")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token isnt \"!!!\"");
            }
            else
            {
                await _Next.Invoke(context);
            }
        }
    }

    public static class MyOwnMdlwExtensions
    {
        public static IApplicationBuilder UseMyOwnMdlw(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyOwnMdlw>();
        }
    };
}
