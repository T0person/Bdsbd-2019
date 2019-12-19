using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(Serv.Serv)))
            {
                host.Open();
                Console.WriteLine("Server started!");
                Console.ReadKey();
            }
        }
    }
}
