using ND21_LogServer.ADOServices;
using ND21_LogServer.Controllers;
using ND21_LogServer.Models.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace ND21_LogServer.App_Start
{
    public class ResolveController: IDependencyResolver
    {
        private static readonly ILogServices LogServices = new ADOLogServices("Data Source=YANA-PC\\SQLEXPRESS;Initial Catalog=logserver_db;Integrated Security=true");
        public object GetService(Type serviceType)
        {
            return serviceType == typeof(LogController) ? new LogController(LogServices) : null;
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }
        public void Dispose()
        {
           
        }
    }
}
    