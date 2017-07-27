using Task.BLL.Services;
using System.Web.Mvc;
using Ninject;
using System.Collections.Generic;
using System;
using Task.BLL.Interfaces;
using Task.BLL.DTO;

namespace Task.Web.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
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
            kernel.Bind<IPerformerService>().To<PerformerService>();
            kernel.Bind<ISongService>().To<SongService>();
            kernel.Bind<IAccordService>().To<AccordService>();
            kernel.Bind<ICommon>().To<CommonService>();
        }
    }
}