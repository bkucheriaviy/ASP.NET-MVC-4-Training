using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EssentialTool.Models;
using EssentialTool.Models.DiscountHelpers;
using Ninject;

namespace EssentialTool.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            _kernel.Bind<ILinqValueCalculator>().To<LinqValueCalculator>();
            _kernel.Bind<IShoppingCart>().To<ShoppingCart>();
            _kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("Discount Size", 50M);
            _kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedExactlyInto<LinqValueCalculator>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}