using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using OneReview.Domain;
using OneReview.Services;

namespace OneReview.Controllers;


[Route("[controller]")]
[ApiController] //for authomatic '[FromBody] [FromHeader etc.]'
public class ReviewsController(ReviewService reviewService) : ControllerBase
{
    private readonly ReviewService _reviewService = reviewService;

    [HttpPost]
    public IActionResult Create(CreateProductRequest request)
    {
        //_reviewService.Create(productId, revie);

        // mapping to external represenstaion
        //return CreatedAtAction(
        //    actionName: nameof(Get),
        //    routeValues: new { ProductId = product.Id },
        //    value: ProductResponse.FromDomain(product)
        //    );

        return Ok();
    }

   

    [HttpGet("{reviewtId:guid}")]
    public IActionResult Get(Guid productId, Guid reviewId)
    {

        var review = _reviewService.Get(productId, reviewId);



        return review is null ?
            Problem(statusCode: StatusCodes.Status404NotFound, detail: $"Review with ReviewId{reviewId} not found")
            : Ok(ReviewResponse.FromDomain(review));
    }

    [HttpGet]
    public IActionResult list(Guid productId)
    {

        var reviews = _reviewService.List(productId);



        return reviews is null ?
            Problem(statusCode: StatusCodes.Status404NotFound, detail: $"Review with ProcuctId{productId} not found")
            : Ok(reviews.Select(ReviewResponse.FromDomain));
    }
}

public record CreateReviewRequest(Guid ProductId, int Rating, string Text)
{
    internal Review ToDomain()
    {
        var review = new Review
        {
            ProductId = ProductId,
            Rating = Rating,
            Text = Text
        };

        return review;

    }
}

public record ReviewResponse(Guid Id, Guid ProductId, int Rating, string Text)
{
    public static ReviewResponse FromDomain(Review product)
    {
        return new ReviewResponse(product.Id, product.ProductId, product.Rating, product.Text);
    }

}