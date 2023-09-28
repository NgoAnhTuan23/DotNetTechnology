using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public Product(int productID, string name, decimal price, string description)
    {
        ProductID = productID;
        Name = name;
        Price = price;
        Description = description;
    }
}

class Customer
{
    public int CustomerID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public Customer(int customerID, string name, string email, string address)
    {
        CustomerID = customerID;
        Name = name;
        Email = email;
        Address = address;
    }
}

class Order
{
    public int OrderID { get; set; }
    public Customer Customer { get; set; }
    public List<Product> Products { get; set; }
    public DateTime OrderDate { get; set; }

    public Order(int orderID, Customer customer, List<Product> products)
    {
        OrderID = orderID;
        Customer = customer;
        Products = products;
        OrderDate = DateTime.Now;
    }
}

class ShoppingCart
{
    private List<Product> cartItems = new List<Product>();

    public void AddToCart(Product product)
    {
        cartItems.Add(product);
    }

    public void RemoveFromCart(Product product)
    {
        cartItems.Remove(product);
    }

    public List<Product> GetCartItems()
    {
        return cartItems;
    }
}

class StoreApp
{
    static void Main(string[] args)
    {
        // Create some products
        Product product1 = new Product(1, "Iphone", 20.25m, "IOS15");
        Product product2 = new Product(2, "Samsung", 15.99m, "Android7");
        Product product3 = new Product(3, "Nokia", 5.99m, "Microsoft");

        // Create a customer
        Customer customer1 = new Customer(1, "Anh Tuan", "Tuandaca23@gmail.com", "1023/5 Le Van Luong");

        // Create a shopping cart for the customer
        ShoppingCart shoppingCart = new ShoppingCart();

        // Add products to the shopping cart
        shoppingCart.AddToCart(product1);
        shoppingCart.AddToCart(product2);

        // Create an order from the shopping cart
        Order order = new Order(1, customer1, shoppingCart.GetCartItems());

        // Display order details
        Console.WriteLine("Order Details:");
        Console.WriteLine($"Order ID: {order.OrderID}");
        Console.WriteLine($"Customer Name: {order.Customer.Name}");
        Console.WriteLine($"Order Date: {order.OrderDate}");
        Console.WriteLine("Products:");
        foreach (var product in order.Products)
        {
            Console.WriteLine($"  {product.Name} - ${product.Price}");
        }
    }
}
