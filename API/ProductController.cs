using DataAccess;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API;

[Route("")]
public class ProductController(MyDbContext context) : ControllerBase
{
    [HttpGet]
    [Route("api/products")]
    public ActionResult GetProducts()
    {
        return Ok(context.Products.ToList());
    }
    
    [HttpPost]
    [Route("api/products")]
    public ActionResult CreateProducts([FromBody] Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
        return Ok(product);
    }
}