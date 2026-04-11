public class Product
{
public int ID {get;set;}
public string Name {get;set;}

public int Price {get; set;}
public int Quantity {get; set;}


public Product(int ID, string Name, int Price, int Quantity)
{

    this.Price = Price;
    this.ID = ID;
    this.Name = Name;
    this.Quantity = Quantity;
}
}




