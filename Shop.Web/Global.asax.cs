namespace Shop.Web
{
    using AutoMapper;
    using Models;
    using ViewModels.Account;
    using ViewModels.Products;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.IO;
    using System.Collections;
    using System.Linq;
    using System;
    using System.Drawing;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RegisterMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMappings()
        {
            Mapper.Initialize(conf =>
            {
                conf.CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(dest => dest.ProfilePicture,
                            mo => mo.MapFrom(src => FileToBytes(src.ProfilePicture)));
                conf.CreateMap<CreateProductVM, Product>()
                .ForMember(dest => dest.ProductImage,
                            mo => mo.MapFrom(src => FileToBytes(src.ProductImage)));
                conf.CreateMap<Product, ListProductsVM>()
                .ForMember(dest => dest.ProductImage,
                            mo => mo.MapFrom(src => BytesToImage(src.ProductImage)));
            });
        }

        private Image BytesToImage(byte[] productImage)
        {
            MemoryStream ms = new MemoryStream(productImage);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private static byte[] FileToBytes(HttpPostedFileBase imageFile)
        {
            if (imageFile == null)
            {
                return new byte[0];
            }

            MemoryStream stream = new MemoryStream();
            imageFile.InputStream.CopyTo(stream);
            return stream.ToArray();
        }
    }
}
