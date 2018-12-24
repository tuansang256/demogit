using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General;
using System.ServiceModel;

namespace WCF_Member_SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            WSHttpBinding binding = new WSHttpBinding();
            Uri address = new Uri("http://localhost:8888/Product");
            ServiceHost host = new ServiceHost(typeof(MemberService));
            host.AddServiceEndpoint(typeof(IMemberService), binding, address);

            host.Open();

            Console.WriteLine("Server Started at {0}", address.ToString());
            Console.WriteLine("Press any key to stop");
            Console.ReadLine();
        }
    }
}
