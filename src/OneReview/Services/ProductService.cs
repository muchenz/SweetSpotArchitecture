using OneReview.Domain;
using OneReview.Persistence.Repositories;

namespace OneReview.Services;

public class ProductService(ProductsRepositoty productsRepositoty)
{

    
    private readonly ProductsRepositoty _productsRepositoty = productsRepositoty;

    public async Task  CreateAsync(Guid UserId, Product product)
    {

       await  _productsRepositoty.CreateAsync(product);


    }

    public async Task<Product?>  GetAsync(Guid productId)
    {
        return await _productsRepositoty.GetByIdAsync(productId);
    }
}
