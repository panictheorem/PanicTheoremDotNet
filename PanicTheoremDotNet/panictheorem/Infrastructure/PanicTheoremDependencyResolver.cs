
using Ninject;
using panictheorem.Domain.Abstract;
using panictheorem.Domain.Concrete;
using panictheorem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace panictheorem.Infrastructure
{
    
    public class PanicTheoremDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public PanicTheoremDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
 
}