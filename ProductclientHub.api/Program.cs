using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductClienthub.api.Controllers;
using ProductClienthub.api.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace ProductClienthub.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona os servi�os necess�rios para controllers e Swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer(); // Necess�rio para Swagger
            builder.Services.AddSwaggerGen();  // Gera a documenta��o do Swagger

            var app = builder.Build();

            // Configura��o do middleware para ambiente de desenvolvimento
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();  // Gera a documenta��o Swagger
                app.UseSwaggerUI();  // Interface para explorar a API
            }

            // Configura��o de redirecionamento para HTTPS
            app.UseHttpsRedirection();

            // Configura o tratamento de exce��es
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature?.Error;

                    if (exception is ProductNotFoundException productNotFoundException)
                    {
                        context.Response.StatusCode = 404;
                        context.Response.ContentType = "application/json";
                        var errorResponse = new { message = exception.Message, productId = productNotFoundException.ProductId };
                        await context.Response.WriteAsJsonAsync(errorResponse);
                    }
                    else
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";
                        var errorResponse = new { message = "An unexpected error occurred." };
                        await context.Response.WriteAsJsonAsync(errorResponse);
                    }
                });
            });

            // Mapeia os controllers
            app.MapControllers();

            // Executa a aplica��o
            app.Run();
        }
    }
}
