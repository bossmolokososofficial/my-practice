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
class Store
{
    private List<Product> products = new List<Product>();
    private int nextCode = 1006;

    public Store()
    {
        products.Add(new Product("1001", "Хлеб", 70, 10, Category.Food));
        products.Add(new Product("1002", "Молоко", 110, 15, Category.Drinks));
        products.Add(new Product("1003", "Клавиатура", 3500, 4, Category.Electronics));
        products.Add(new Product("1004", "Футболка", 1800, 7, Category.Clothes));
        products.Add(new Product("1005", "Сок", 150, 0, Category.Drinks));
    }
}