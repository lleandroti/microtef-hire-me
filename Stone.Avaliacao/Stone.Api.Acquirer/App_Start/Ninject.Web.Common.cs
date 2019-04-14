using Ninject.Web.Common.WebHost;
using Stone.Domain.Contracts;
using Stone.Domain.Contracts.Repository;
using Stone.Domain.Contracts.Services;
using Stone.Domain.Services;
using Stone.Domain.Services.DomainServices;
using Stone.Persistence.Repository;
using Stone.Persistence.Repository.Repositories;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Stone.Api.Acquirer.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Stone.Api.Acquirer.App_Start.NinjectWebCommon), "Stop")]

namespace Stone.Api.Acquirer.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                GlobalConfiguration.Configuration.DependencyResolver = 
                    kernel.Get<System.Web.Http.Dependencies.IDependencyResolver>();

                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //nivel do dominio..
            kernel.Bind(typeof(IDomainServiceBase<,>)).To(typeof(DomainServiceBase<,>));

            kernel.Bind<IDomainServiceBandeira>().To<DomainServiceBandeira>();
            kernel.Bind<IDomainServiceCartao>().To<DomainServiceCartao>();
            kernel.Bind<IDomainServiceCliente>().To<DomainServiceCliente>();
            kernel.Bind<IDomainServiceTransacao>().To<DomainServiceTransacao>();

            //nivel do repositorio..
            kernel.Bind(typeof(IRepositoryBase<,>)).To(typeof(RepositoryBase<,>));

            kernel.Bind<IRepositoryBandeira>().To<RepositoryBandeira>();
            kernel.Bind<IRepositoryCartao>().To<RepositoryCartao>();
            kernel.Bind<IRepositoryCliente>().To<RepositoryCliente>();
            kernel.Bind<IRepositoryTransacao>().To<RepositoryTransacao>();
        }
    }
}