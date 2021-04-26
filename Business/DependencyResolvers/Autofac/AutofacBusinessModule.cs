using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<EfBasketDal>().As<IBasketDal>();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            builder.RegisterType<EfCityDal>().As<ICityDal>();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();
            builder.RegisterType<EfOrderStatuDal>().As<IOrderStatuDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<BasketManager>().As<IBasketService>();
            builder.RegisterType<AddressManager>().As<IAddressService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<CityManager>().As<ICityService>();
            builder.RegisterType<CountryManager>().As<ICountryService>();
            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<BasketManager>().As<IBasketService>();
            builder.RegisterType<UserManager>().As<IUserService>();


            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
