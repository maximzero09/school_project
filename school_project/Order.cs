class Order
{
    public int Id { get; set; }
    public string ClientName { get; set; }
    public List<Product> Products { get; set; }
    public int TotalPrice { get; set; }

    public Order(int id, string clientName, List<Product> products)
    {
        Id = id;
        ClientName = clientName;
        Products = products;
        TotalPrice = products.Sum(p => p.Price * p.Quantity);
    }
}
