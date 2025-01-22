using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClienthub.api.Exceptions; // Importando a exceção personalizada
using System;

namespace ProductClienthub.api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Verifica se é uma exceção do tipo ProductNotFoundException
            if (context.Exception is ProductNotFoundException productNotFoundException)
            {
                // Retorna uma resposta com o código de status 404 e a mensagem da exceção
                context.Result = new NotFoundObjectResult(new
                {
                    message = productNotFoundException.Message,
                    productId = productNotFoundException.ProductId
                });
                context.ExceptionHandled = true;
            }
            else
            {
                // Para outras exceções, envia uma resposta genérica de erro
                context.Result = new ObjectResult(new { message = "An unexpected error occurred." })
                {
                    StatusCode = 500
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
