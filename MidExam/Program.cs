namespace MidExam;

class TrueNature
{
    static List<Item> TrueNatureInverntory = new List<Item>();
    static void Main(string[] args)
    {
        //create store named "TrueNature Nursery"
        Store store = new Store("TrueNature Nursery", "547 Belmont Ave Kitchener", "Cherryl", "Patel");

        Nursery nursery = new Nursery(store.StoreName, store.StoreAddress, store.StoreOwnerFirstName, store.StoreOwnerLastName, TrueNatureInverntory);

        Initialize();
        WelcomeMessage(nursery);
        DisplayOptions(nursery);
    }

    static void Initialize()
    {
        //add 3 hardcoded inventory items
        TrueNatureInverntory.Add(new Item { Name = "Sunflower Seeds", Quantity = 2, PricePerUnit = 40, TotalItemValue = 80 });
        TrueNatureInverntory.Add(new Item { Name = "Rose Plant", Quantity = 10, PricePerUnit = 50, TotalItemValue = 500 });
        TrueNatureInverntory.Add(new Item { Name = "Lotus", Quantity = 20, PricePerUnit = 50, TotalItemValue = 1000 });
    }

    static void WelcomeMessage(Nursery nursery)
    {
        Console.WriteLine("\n----------------------------------------------");
        Console.WriteLine("------   WelCome to {0}  ------", nursery.StoreName);
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Owner : {0} {1}", nursery.StoreOwnerFirstName, nursery.StoreOwnerLastName);
        Console.WriteLine("Address : {0}", nursery.StoreAddress);
        Console.WriteLine("----------------------------------------------");
    }

    static void DisplayOptions(Nursery nursery)
    {
        while (true)
        {
            Console.WriteLine("\nChoose an option below:");
            Console.WriteLine("1. Add a New Item to the Inventory");
            Console.WriteLine("2. Display All Items");
            Console.WriteLine("3. Delete an Individual Item from the Inventory");
            Console.WriteLine("4. Clear Inventory");
            Console.WriteLine("5. Exit the program");

            if (int.TryParse(Console.ReadLine(), out int userOption) && userOption >= 6)
            {
                Console.WriteLine("Invalid input. Please enter valid option.");
                continue;
            }

            switch (userOption)
            {
                case 1:
                    AddNewItem();
                    break;
                case 2:
                    DisplayInventory();
                    break;
                case 3:
                    DeleteItem(nursery);
                    break;
                case 4:
                    ClearInventory();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input , Try again\n");
                    break;
            }

        }

    }

    static void AddNewItem()
    {
        try
        {
            //get ItemName
            string itemName = "";
            bool validItemName = false;

            while (!validItemName)
            {
                Console.Write("Enter Name of Item: ");
                itemName = Console.ReadLine()!;
                if (itemName.ToString() == "" && itemName.Trim() == "")
                {

                    Console.WriteLine("Invalid input.Try again.");

                }
                else
                {
                    validItemName = true;
                }
            }

            //get Quantity Of Item
            int itemQuantity = 0;
            bool validQuantity = false;

            while (!validQuantity)
            {
                Console.Write("Enter quantity of {0}: ", itemName);
                if (int.TryParse(Console.ReadLine(), out itemQuantity) && itemQuantity > 0)
                {
                    validQuantity = true;
                }
                else
                {
                    Console.WriteLine("Invalid input.Try again.");
                }
            }

            //get Item Price Per Unit
            double itemPrice = 0;
            bool validPrice = false;

            while (!validPrice)
            {
                Console.Write("Enter price per unit: ");
                if (double.TryParse(Console.ReadLine(), out itemPrice) && itemPrice > 0)
                {
                    validPrice = true;
                }
                else
                {
                    Console.WriteLine("Invalid input.Try again.");
                }
            }

            //calculate TotalItemPrice
            double itemTotalAmmount = itemQuantity * itemPrice;

            //add new item to TrueNatureInverntory
            TrueNatureInverntory.Add(
                new Item
                {
                    Name = itemName,
                    Quantity = itemQuantity,
                    PricePerUnit = itemPrice,
                    TotalItemValue = itemTotalAmmount
                });

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

    }

    static void DisplayInventory()
    {
        if (TrueNatureInverntory.Count == 0)
        {
            //when Inventory is empty
            Console.WriteLine("No item available in Inventory\n");
        }
        else
        {
            Console.WriteLine("\nTrueNature Inventory List:\n");

            for (int i = 0; i < TrueNatureInverntory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {TrueNatureInverntory[i].Name}, Quantity: {TrueNatureInverntory[i].Quantity}, Price per unit: ${TrueNatureInverntory[i].PricePerUnit}, Total Value: ${TrueNatureInverntory[i].TotalItemValue}");
                Console.WriteLine("------------------------------------------------------------------------------");
            }
        }


    }

    static void DeleteItem(Nursery nursery)
    {
        //display Items using DisplayInventory()
        DisplayInventory();

        if (TrueNatureInverntory.Count == 0)
        {
            Console.WriteLine("there is nothing to remove.\n");
        }
        else
        {
            while (true)
            {

                Console.Write("Enter the number of the item to delete: ");

                if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= TrueNatureInverntory.Count)
                {

                    TrueNatureInverntory.RemoveAt(index - 1);
                    Console.WriteLine("\nItem deleted successfully!");

                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }

        }

    }

    static void ClearInventory()
    {
        //clear TrueNatureInverntory
        TrueNatureInverntory.Clear();
        Console.WriteLine("Inventory cleared successfully!");
    }

}
