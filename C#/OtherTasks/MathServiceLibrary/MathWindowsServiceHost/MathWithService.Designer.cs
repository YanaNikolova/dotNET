using MathServiceLibrary;
using System;
using System.ServiceModel;
using System.ServiceProcess;
namespace MathWindowsServiceHost
{
    public partial class MathWithService : ServiceBase
    {
        // A member variable of type ServiceHost.
        private ServiceHost myHost;

        public MathWithService()
        {
            /*InitializeComponent();*/
        }
        protected override void OnStart(string[] args)
        {
            if (myHost != null)
            {
                myHost.Close();
            }
            // Create the host and specify a URL for an HTTP binding.
            myHost = new ServiceHost(typeof(MathService),
            new Uri("http://localhost:8080/MathServiceLibrary"));
            // Opt in for the default endpoints!
            myHost.AddDefaultEndpoints();
            // Open the host.
            myHost.Open();
        }
        protected override void OnStop()
        {
            // Shut down the host.
            if(myHost != null)
            myHost.Close();
        }
    }
}