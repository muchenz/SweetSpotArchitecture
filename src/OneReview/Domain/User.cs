namespace OneReview.Domain;

public class User
{
    public Guid Id { get; init; }

    public List<Product> Products { get; init; } = [];

    internal void AddProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
