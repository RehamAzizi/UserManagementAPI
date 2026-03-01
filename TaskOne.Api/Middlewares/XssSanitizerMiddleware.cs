using Ganss.Xss;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class XssSanitizerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HtmlSanitizer _sanitizer;
    public XssSanitizerMiddleware(RequestDelegate next)
    {
        _next = next;
        _sanitizer = new HtmlSanitizer();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // فحص Query String
        foreach (var key in context.Request.Query.Keys)
        {
            var value = context.Request.Query[key];
            var cleanValue = _sanitizer.Sanitize(value);
            if (value != cleanValue)
            {
                context.Request.QueryString = ReplaceQueryString(
                    context.Request.QueryString,
                    key,
                    cleanValue
                );
            }
        }

        // فحص Body (JSON أو Form)
        if (context.Request.ContentLength > 0 && context.Request.Body.CanRead)
        {
            context.Request.EnableBuffering();
            using var reader = new StreamReader(
                context.Request.Body,
                Encoding.UTF8,
                leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            var cleanBody = _sanitizer.Sanitize(body);
            context.Request.Body.Position = 0;
            if (body != cleanBody)
            {
                var bytes = Encoding.UTF8.GetBytes(cleanBody);
                context.Request.Body = new MemoryStream(bytes);
            }
        }
        await _next(context);
    }
    private QueryString ReplaceQueryString(
        QueryString queryString,
        string key,
        string value)
    {
        var newQuery = Microsoft.AspNetCore.WebUtilities
            .QueryHelpers.ParseQuery(queryString.ToString());
        newQuery[key] = value;
        var qb = new QueryBuilder();
        foreach (var item in newQuery)
            qb.Add(item.Key, item.Value.ToString());
        return qb.ToQueryString();
    }
}