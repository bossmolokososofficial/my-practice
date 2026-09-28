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
using System;
using System.Collections.Generic;

enum Category
{
    Food = 1,
    Drinks,
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
        get
        {
            return Count > 0;
        }
    }

    public Product(string code, string name, decimal price, int count, Category category)
    {
        Code = code;
        Name = name;
        Price = price;
        Count = count;
        Category = category;
    }

    public void PrintInfo()
    {
        Console.WriteLine("--------------------");
        Console.WriteLine($"Код: {Code}");
        Console.WriteLine($"Название: {Name}");
        Console.WriteLine($"Цена: {Price} руб.");
        Console.WriteLine($"Количество: {Count}");
        Console.WriteLine($"На складе: {(InStock ? "Да" : "Нет")}");
        Console.WriteLine($"Категория: {Category}");
        Console.WriteLine("--------------------");
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

    public void ShowAllProducts()
    {
        Console.WriteLine("=== Все товары ===");

        foreach (Product product in products)
        {
            product.PrintInfo();
        }
    }

    public void AddProduct()
    {
        Console.Write("Введите название товара: ");
        string name = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Название не может быть пустым.");
            return;
        }

        Console.Write("Введите цену товара: ");

        decimal price;

        if (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
        {
            Console.WriteLine("Цена введена неправильно.");
            return;
        }

        Console.Write("Введите количество товара: ");

        int count;

        if (!int.TryParse(Console.ReadLine(), out count) || count < 0)
        {
            Console.WriteLine("Количество введено неправильно.");
            return;
        }

        Console.WriteLine("Выберите категорию:");
        Console.WriteLine("1 - Food");
        Console.WriteLine("2 - Drinks");
        Console.WriteLine("3 - Electronics");
        Console.WriteLine("4 - Clothes");

        int categoryNumber;

        if (!int.TryParse(Console.ReadLine(), out categoryNumber)
            || categoryNumber < 1
            || categoryNumber > 4)
        {
            Console.WriteLine("Такой категории нет.");
            return;
        }

        string code = nextCode.ToString();

        nextCode++;

        Product product = new Product(
            code,
            name,
            price,
            count,
            (Category)categoryNumber
        );

        products.Add(product);

        Console.WriteLine($"Товар добавлен. Код товара: {code}");
    }

    public void DeleteProduct()
    {
        Console.Write("Введите код товара: ");

        string code = Console.ReadLine() ?? "";

        Product product = FindByCode(code);

        if (product == null)
        {
            Console.WriteLine("Товар не найден.");
            return;
        }

        products.Remove(product);

        Console.WriteLine("Товар удалён.");
    }

    private Product FindByCode(string code)
    {
        foreach (Product product in products)
        {
            if (product.Code == code)
            {
                return product;
            }
        }

        return null;
    }
}

class Program
{
    static void Main()
    {
        Store store = new Store();

        store.ShowAllProducts();

        Console.WriteLine();
        Console.WriteLine("Добавление товара:");

        store.AddProduct();

        Console.WriteLine();
        store.ShowAllProducts();

        Console.WriteLine();
        Console.WriteLine("Удаление товара:");

        store.DeleteProduct();

        Console.WriteLine();
        store.ShowAllProducts();
    }
}
using System;
using System.Collections.Generic;

enum Category
{
    Food = 1,
    Drinks,
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
        get
        {
            return Count > 0;
        }
    }

    public Product(string code, string name, decimal price, int count, Category category)
    {
        Code = code;
        Name = name;
        Price = price;
        Count = count;
        Category = category;
    }

    public void PrintInfo()
    {
        Console.WriteLine("--------------------");
        Console.WriteLine($"Код: {Code}");
        Console.WriteLine($"Название: {Name}");
        Console.WriteLine($"Цена: {Price} руб.");
        Console.WriteLine($"Количество: {Count}");
        Console.WriteLine($"На складе: {(InStock ? "Да" : "Нет")}");
        Console.WriteLine($"Категория: {Category}");
        Console.WriteLine("--------------------");
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

    public void ShowAllProducts()
    {
        Console.WriteLine("=== Все товары ===");

        foreach (Product product in products)
        {
            product.PrintInfo();
        }
    }

    public void AddProduct()
    {
        Console.Write("Введите название товара: ");
        string name = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Название не может быть пустым.");
            return;
        }

        Console.Write("Введите цену товара: ");

        decimal price;

        if (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
        {
            Console.WriteLine("Цена введена неправильно.");
            return;
        }

        Console.Write("Введите количество товара: ");

        int count;

        if (!int.TryParse(Console.ReadLine(), out count) || count < 0)
        {
            Console.WriteLine("Количество введено неправильно.");
            return;
        }

        Console.WriteLine("Выберите категорию:");
        Console.WriteLine("1 - Food");
        Console.WriteLine("2 - Drinks");
        Console.WriteLine("3 - Electronics");
        Console.WriteLine("4 - Clothes");

        int categoryNumber;

        if (!int.TryParse(Console.ReadLine(), out categoryNumber)
            || categoryNumber < 1
            || categoryNumber > 4)
        {
            Console.WriteLine("Такой категории нет.");
            return;
        }

        string code = nextCode.ToString();

        nextCode++;

        Product product = new Product(
            code,
            name,
            price,
            count,
            (Category)categoryNumber
        );

        products.Add(product);

        Console.WriteLine($"Товар добавлен. Код товара: {code}");
    }

    public void DeleteProduct()
    {
        Console.Write("Введите код товара: ");

        string code = Console.ReadLine() ?? "";

        Product product = FindByCode(code);

        if (product == null)
        {
            Console.WriteLine("Товар не найден.");
            return;
        }

        products.Remove(product);

        Console.WriteLine("Товар удалён.");
    }

    public void SupplyProduct()
    {
        Console.Write("Введите код товара: ");

        string code = Console.ReadLine() ?? "";

        Product product = FindByCode(code);

        if (product == null)
        {
            Console.WriteLine("Товар не найден.");
            return;
        }

        Console.Write("Введите количество для поставки: ");

        int count;

        if (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
        {
            Console.WriteLine("Количество должно быть больше 0.");
            return;
        }

        product.Count += count;

        Console.WriteLine("Поставка выполнена.");
        Console.WriteLine($"Теперь товара на складе: {product.Count}");
    }

    public void SellProduct()
    {
        Console.Write("Введите код товара: ");

        string code = Console.ReadLine() ?? "";

        Product product = FindByCode(code);

        if (product == null)
        {
            Console.WriteLine("Товар не найден.");
            return;
        }

        if (!product.InStock)
        {
            Console.WriteLine("Товара нет на складе.");
            return;
        }

        Console.Write("Введите количество для продажи: ");

        int count;

        if (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
        {
            Console.WriteLine("Количество должно быть больше 0.");
            return;
        }

        if (count > product.Count)
        {
            Console.WriteLine("Недостаточно товара на складе.");
            Console.WriteLine($"Доступно: {product.Count}");
            return;
        }

        product.Count -= count;

        Console.WriteLine("Товар успешно продан.");
        Console.WriteLine($"Осталось на складе: {product.Count}");
    }

    private Product FindByCode(string code)
    {
        foreach (Product product in products)
        {
            if (product.Code == code)
            {
                return product;
            }
        }

        return null;
    }
}

class Program
{
    static void Main()
    {
        Store store = new Store();

        store.ShowAllProducts();

        Console.WriteLine();
        Console.WriteLine("Поставка товара:");

        store.SupplyProduct();

        Console.WriteLine();
        Console.WriteLine("Продажа товара:");

        store.SellProduct();

        Console.WriteLine();
        store.ShowAllProducts();
    }
}