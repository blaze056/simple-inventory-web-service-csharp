using System;
//using System.ServiceModel;
//using System.ServiceModel.Channels;
//using Microsoft.WCF.Documentation;

namespace WebServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WebServiceClient wcfClient = new WebServiceClient();

            Console.WriteLine("Enter the text to HelloWorld method:");
            string greeting = Console.ReadLine();
            Console.WriteLine("The service responded: " + wcfClient.HelloWorld(greeting));

        }
    }
}
