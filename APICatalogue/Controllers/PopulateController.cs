using APICatalogue.Context;
using APICatalogue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogue.Controllers;
[Route("[controller]")]
[ApiController]

public class PopulateController : ControllerBase
{
    private readonly AppDbContext _context;

    public PopulateController(AppDbContext context)
    {
        _context = context;
    }
    
    [Route("Categories")]
    [HttpPost]
    public ActionResult<Category> PopulateCategories()
    {
        
        Category beverages = new Category();
        beverages.Name = "Beverages";
        beverages.ImageUrl = "beverages.png";
        
        Category toys = new Category();
        toys.Name = "Toys";
        toys.ImageUrl = "toys.png";
        
        Category clothes = new Category();
        clothes.Name = "Clothes";
        clothes.ImageUrl = "clothes.png";
        
        var categories = new List<Category>{clothes,  toys, beverages};
        
        _context.Categories.AddRange(categories);
        _context.SaveChanges();
        return Ok(categories);
    }
    
    [Route("Products")]
    [HttpPost]
    public ActionResult<Product> PopulateProducts()
    {
        Product dCoke = new Product();
        dCoke.Name = "Diet Coke";
        dCoke.Description = "A coke that is also diet.";
        dCoke.Price = 4.3M;
        dCoke.ImageUrl = "diet-coke-png";
        dCoke.Stock = 5;
        dCoke.Created = DateTime.Now;
        dCoke.CategoryId = 1;

        Product bPants = new Product();
        bPants.Name = "Black Pants";
        bPants.Description = "Pants that are black.";
        bPants.Price = 15;
        bPants.ImageUrl = "black-pants-png";
        bPants.Stock = 10;
        bPants.Created = DateTime.Now;
        bPants.CategoryId = 3;
        
        Product omnitrix = new Product();
        omnitrix.Name = "Omnitrix";
        omnitrix.Description = "Ben 10's iconic watch.";
        omnitrix.Price = 20.5M;
        omnitrix.ImageUrl = "omnitrix-png";
        omnitrix.Stock = 1;
        omnitrix.Created = DateTime.Now;
        omnitrix.CategoryId = 2;
        
        var products = new List<Product>{dCoke, bPants, omnitrix};
        
        _context.Products.AddRange(products);
        _context.SaveChanges();
        return Ok(products);
    }
}