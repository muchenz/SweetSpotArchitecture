using OneReview.Domain;

namespace OneReview.Services;

public class ProductService
{

    private static readonly List<Product> ProductRepository = [];
    private static readonly List<User> UserRepository = [];

    public void Create(Guid UserId, Product product)
    {
       // User user = UserRepository.Find(a=>a.Id==UserId)?? throw new InvalidOperationException();


        //user.AddProduct(product);
        
        ProductRepository.Add(product);


    }

    public Product?  Get(Guid productId)
    {
        return ProductRepository.Find(a=>a.Id == productId);
    }
}
