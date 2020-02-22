using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{

    //class Commodity
    //{
    //    public string id; public string name; public string typeno; public string type; public string price; public string brand; public string size; public string stock;
    //}
    class Program 
    {
        static void Main(string[] args)
        {
            string userresponse = "";
            bool loopContinue;
            ServiceReference1.Service1Client wcfClient = new ServiceReference1.Service1Client();
            Dictionary<string, string> CommodityList = new Dictionary<string, string>();
            // Dictionary<string, string> CommodityList = wcfClient;
                        
            loopContinue = true;
            while (loopContinue)
            {
                Console.WriteLine("### Welcome To Client Console Application! ###\n\n " +
                "Please choose an option:\n" +
                "a) Search for commodity\n " +
                "b) Enter new commodity\n " +
                "c) Show all Laptops\n" +
                "d) Add a new feature to a commodity type\n" +
                "*) Any other key to exit\n");
                Console.WriteLine("Enter the Option (a | b | c) : ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "a":
                        Console.WriteLine("Enter type number or feature name as per table in database : ");
                        userresponse = Console.ReadLine();
                        Console.WriteLine("The service responded: \n" + wcfClient.SearchCommodity(userresponse));
                        loopContinue = true;
                        Console.WriteLine("------------------------------------------------\n");
                        break;

                    case "b":
                        Console.WriteLine("Please enter the commodity details...");
                        Console.WriteLine("Enter id:");
                        string id = Console.ReadLine();
                        Console.WriteLine("Enter name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter typeno:");
                        string typeno = Console.ReadLine();
                        Console.WriteLine("Enter type:");
                        string type = Console.ReadLine();
                        Console.WriteLine("Enter price:");
                        string price = Console.ReadLine();
                        Console.WriteLine("Enter brand:");
                        string brand = Console.ReadLine();
                        Console.WriteLine("Enter size:");
                        string size = Console.ReadLine();
                        Console.WriteLine("Enter stock:");
                        string stock = Console.ReadLine();

                        CommodityList.Add("id", id);
                        CommodityList.Add("name", name);
                        CommodityList.Add("typeno", typeno);
                        CommodityList.Add("type", type);
                        CommodityList.Add("price", price);
                        CommodityList.Add("brand", brand);
                        CommodityList.Add("size", size);
                        CommodityList.Add("stock", stock);

                        // We need to convert the input into JSON, serialize it and send to service.
                        // Or we need to figure out way to type convert the CommodityList Ditionary object into an object of ServiceReference1.Service1Client.
                        // Console.WriteLine("The service responded: " + wcfClient.AddCommodity(CommodityList));
                        loopContinue = true;
                        Console.WriteLine("------------------------------------------------\n");
                        break;

                    case "c":
                        Console.WriteLine("The service responded: \n" + wcfClient.ListAllLaptops());

                        loopContinue = true;
                        Console.WriteLine("------------------------------------------------\n");
                        break;

                    case "d":
                        Console.WriteLine("Enter Type number of the commodity type:");
                        string typeno2 = Console.ReadLine();
                        Console.WriteLine("Enter Feature number:");
                        string featureno = Console.ReadLine();
                        Console.WriteLine("Enter the new Feature to add:");
                        string feature = Console.ReadLine();
                        //Console.WriteLine("The service responded: \n" + wcfClient.AddNewFeature(typeno2,featureno,feature));

                        loopContinue = true;
                        Console.WriteLine("------------------------------------------------\n");
                        break;

                    default:
                        loopContinue = false;
                        Console.WriteLine("Goodbye!");
                        System.Threading.Thread.Sleep(2500);
                        break;
                }
                
            }
        }
    }
}
