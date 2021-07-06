using System;
using System.Configuration;

namespace WYQ
{
    class Program
    { 
        static void Main(string[] args)
        { 
                try
                {
                     DB.MySqlConncetion.ConnectTest();

                    string apiPort = ConfigurationSettings.AppSettings["ApiPort"].ToString();
                    string serverURL = $"http://localhost:{apiPort}/";
                    Console.WriteLine($"正在启动WebApi Server :{serverURL}api/test");
                    // Start OWIN host 
                    Microsoft.Owin.Hosting.WebApp.Start<StartupAppBuilder>(url: serverURL);
                    Console.WriteLine("启动WepApi 服务器成功.");
                    // Create HttpCient and make a request to api/products 
                    System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

                    var response = client.GetAsync($"{serverURL}api/Test").Result;

                    //  Console.WriteLine(response);

                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    if (ex.InnerException != null) msg = msg + "\r\n" + ex.InnerException.Message;
                    Console.WriteLine("启动异常：" + msg);
                    Console.ReadLine();
                } 

            var key = Console.ReadKey();
            while (key.Key != ConsoleKey.Q)
            {
                Console.WriteLine("\r\n程序运行中请勿退出或关闭，如要退出请按 Q 键或关闭窗口,程序也将终止");
                key = Console.ReadKey();
            }
            Console.ReadKey();
        } 
    }
}
