using System;
using System.Net;

namespace GameAPITester
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string uri = "http://localhost:4000/api/games/1234";

                using (WebClient client = new WebClient())
                {
                    Console.WriteLine(client.DownloadString(uri));
                }

                if (Console.ReadKey().Key == ConsoleKey.A)
                    break;
            }
        }
    }
}
