[assembly: WebActivatorEx.PreApplicationStartMethodAttribute(typeof(BeerMan.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BeerMan.App_Start.NinjectWebCommon), "Stop")]

namespace BeerMan.App_Start
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using BeerMan.Models;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Ninject.Web.Mvc;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));

            bootstrapper.Initialize(CreateKernel);
        }      
        public static void Stop() =>
            bootstrapper.ShutDown();
        
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }


        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<BeermanContext>().To<BeermanContext>();
        }
           
    }
}