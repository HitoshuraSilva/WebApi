using APICatalogue.Context;
using APICatalogue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public ActionResult PostProduct(Product product)
    {
        if (product is null)
        {
            return BadRequest();
        }
        
        _context.Products.Add(product);
        _context.SaveChanges();

        return new CreatedAtRouteResult("GetProduct", new { id = product.ProductId }, product);
    }

    [HttpPut("{id:int}")]
    public ActionResult PutProduct(int id, Product product)
    {
        if (id != product.ProductId)
        {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(product);
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteProduct(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
        if (product is null)
        {
            return NotFound("Product not found");
        }
        _context.Products.Remove(product);
        _context.SaveChanges();
        
        return Ok(product);
    }
}