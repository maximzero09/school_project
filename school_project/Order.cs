public class Order
{
int ID;
string CustomerName;
string ProductName;
int Quantity;
int TotalPrice;

    
public Order(int ID, string CustomerName, string ProductName, int Quantity, int TotalPrice)
{
    this.ID = ID;
    this.Quantity = Quantity;
    this.TotalPrice = TotalPrice;
    this.CustomerName = CustomerName;
    this.ProductName = ProductName;

}
}
