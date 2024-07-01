﻿using Microsoft.AspNetCore.Mvc;
using OneReview.Domain;
using OneReview.Services;

namespace OneReview.Controllers;

[Route("[controller]")]
[ApiController] //for authomatic '[FromBody] [FromHeader etc.]'
public class ProductsController(ProductService productService) : ControllerBase
{
    private readonly ProductService _productService=productService;

    [HttpPost]
    public IActionResult Create(CreateProductRequest request)
    {
        var userId = Guid.Parse("649fa8cf-ece6-431f-beee-dd55802268ff");

        //mapping to internal represenstaion
        var product = request.ToDomain();

        //invoking use case
        _productService.Create(userId, product);

        // mapping to external represenstaion
        return CreatedAtAction(
            actionName: nameof(Get),
            routeValues: new { ProductId = product.Id },
            value: ProductResponse.FromDomain(product)
            );
    }

    [HttpGet("{productId:guid}")]
    public IActionResult Get(Guid productId)
    {

        var product = _productService.Get(productId);



        return product is null?
            Problem(statusCode: StatusCodes.Status404NotFound, detail: $"Product with Id{productId} not found")
            :Ok(ProductResponse.FromDomain(product));
    }
}

public record CreateProductRequest(string Name, string Category, string SubCategory)
{
    internal Product ToDomain()
    {
        var product = new Product
        {
            Name = Name,
            Category = Category,
            SubCategory = SubCategory
        };

        return product;

    }
}

public record ProductResponse(Guid Id, string Name, string Category, string SubCategory)
{
    public static ProductResponse FromDomain(Product product)
    {
        return new ProductResponse(product.Id, product.Name, product.Category, product.SubCategory);
    }

}