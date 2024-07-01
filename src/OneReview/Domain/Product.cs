namespace OneReview.Domain;

public class Product
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Category { get; set; }
    public string SubCategory { get; set; }
}
