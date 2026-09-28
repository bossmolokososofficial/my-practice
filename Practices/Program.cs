enum Category
{
    Food = 1,
    Drink,
    Electronics,
    Clothes
}
    
class Product
{
    public string Code { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public Category Category { get; set; }

    public bool InStock
    {
        get { return Count > 0; }
    }
    public Product(string code, string name, decimal price, int count, Category category)
    {
        Code = code;
        Name = name;
        Price = price;
        Count = count;
        Category = category;
    }
}