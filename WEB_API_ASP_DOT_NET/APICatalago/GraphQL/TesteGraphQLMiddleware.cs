using APICatalago.Repository;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalago.GraphQL
{
    public class TesteGraphQLMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IUnitOfWork _context;

        public TesteGraphQLMiddleware(RequestDelegate next, IUnitOfWork context)
        {
            _next = next;
            _context = context;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/graphql"))
            {
                using (var stream = new StreamReader(httpContext.Request.Body))
                {
                    var query = await stream.ReadToEndAsync();

                    if (!String.IsNullOrWhiteSpace(query))
                    {
                        var schema = new Schema
                        {
                            Query = new CategoriaQuery(_context)
                        };

                        var result =  await new DocumentExecuter().ExecuteAsync(options => 
                        {
                            options.Schema = schema;
                            options.Query = query;
                        });

                        await WriteResult(httpContext, result);
                    }
                }
            }
        }

        private async Task WriteResult(HttpContext httpContext, ExecutionResult result)
        {
            //var json = new DocumentWriter()
        }
    }
}
