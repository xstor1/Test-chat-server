using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;

namespace ChatClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        static async Task GetRequest(string id)
        {
            switch (id)
            {
                //Get Request    
                case "Get":
                    Console.WriteLine("Enter id:");
                    int ID1 = Convert.ToInt32(Console.ReadLine());
                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri("http://localhost:56843/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response;
                        response = await client.GetAsync("api/values");
                        if (response.IsSuccessStatusCode)
                        {
                            string reports = await response.Content.ReadAsAsync<string>();
                            Console.WriteLine(reports);
                        }
                    }
                    break;
            }
       
        }
    }
}
