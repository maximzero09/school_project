public class Customer
{
int ID {get; set;} 
string  Name {get; set;} 
string  Email {get; set;} 



public Customer(int ID, string Name, string Email)
{
    this.ID = ID;
    this.Name = Name;
    this.Email = Email;
}

}
