class Store
{
    public String StoreName;
    public String StoreAddress;
    public String StoreOwnerFirstName;
    public String StoreOwnerLastName;

    public Store(string storeName, string storeAddress, string firstName, string lastName)
    {
        StoreName = storeName;
        StoreAddress = storeAddress;
        StoreOwnerFirstName = firstName;
        StoreOwnerLastName = lastName;
    }
}

class Nursery : Store
{
    public List<Item> NurseryInventory;
    public Nursery(string storeName, string storeAddress, string firstName, string lastName, List<Item> nurseryInventory) : base(storeName, storeAddress, firstName, lastName)
    {
        NurseryInventory = nurseryInventory;
    }
}

public class Item
{
    public string? Name;
    public int Quantity;
    public double PricePerUnit;
    public double TotalItemValue;

    //use to calculate totalItemValue
    public double CalculateTotalItemValue()
    {
        return Quantity * PricePerUnit;
    }
}
