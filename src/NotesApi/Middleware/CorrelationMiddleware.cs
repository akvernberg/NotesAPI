using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Threading.Tasks;

namespace NotesApi.Middleware
{
    public class CorrelationMiddleware
    {
        private const string Header = "X-Correlation-ID";

        private readonly RequestDelegate _next;

        public CorrelationMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue(Header, out StringValues correlationId))
            {
                context.TraceIdentifier = correlationId;
            }

            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Add(Header, new[] { context.TraceIdentifier });
                return Task.CompletedTask;
            });

            return _next(context);
        }
    }
}
