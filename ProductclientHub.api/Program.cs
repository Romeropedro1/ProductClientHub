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

            // Adiciona os serviços necessários para controllers e Swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer(); // Necessário para Swagger
            builder.Services.AddSwaggerGen();  // Gera a documentação do Swagger

            var app = builder.Build();

            // Configuração do middleware para ambiente de desenvolvimento
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();  // Gera a documentação Swagger
                app.UseSwaggerUI();  // Interface para explorar a API
            }

            // Configuração de redirecionamento para HTTPS
            app.UseHttpsRedirection();

            // Configura o tratamento de exceções
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

            // Executa a aplicação
            app.Run();
        }
    }
}
