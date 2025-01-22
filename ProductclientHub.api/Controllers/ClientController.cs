using Microsoft.AspNetCore.Mvc;
using ProductClienthub.api.Exceptions;  // Exceção personalizada
using ProductClienthub.api.Models;  // Importa o namespace do modelo Product
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProductClienthub.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 100 },
            new Product { Id = 2, Name = "Product 2", Price = 200 },
            new Product { Id = 3, Name = "Product 3", Price = 300 }
        };

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(Products);
        }

        // GET api/products/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new ProductNotFoundException(id);  // Lança a exceção personalizada
            }
            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product newProduct)
        {
            if (!ModelState.IsValid)  // Verifica se o modelo é válido
            {
                return BadRequest(ModelState);  // Retorna os erros de validação
            }

            // Gera ID único
            newProduct.Id = Products.Max(p => p.Id) + 1;
            Products.Add(newProduct);

            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }

        // PUT api/products/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            if (!ModelState.IsValid)  // Verifica se o modelo é válido
            {
                return BadRequest(ModelState);  // Retorna os erros de validação
            }

            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new ProductNotFoundException(id);  // Lança a exceção personalizada
            }

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return NoContent();
        }

        // DELETE api/products/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new ProductNotFoundException(id);  // Lança a exceção personalizada
            }

            Products.Remove(product);

            return NoContent();
        }
    }
}
