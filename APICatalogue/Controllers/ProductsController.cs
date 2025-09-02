using APICatalogue.Context;
using APICatalogue.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogue.Controllers;
[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        var products  = _context.Products.ToList();
        if (products is null)
        {
            return NotFound("Products not found.");
        }
        return products;
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
        if (product is null)
        {
            return NotFound("Product not found.");
        }

        return product;
    }

    [HttpPost]
    public ActionResult PostProduct([FromBody] Product product)
    {
        if (product is null)
        {
            return BadRequest();
        }
        
        _context.Products.Add(product);
        _context.SaveChanges();

        return new CreatedAtRouteResult("GetProduct", new { id = product.ProductId }, product);
    }
}