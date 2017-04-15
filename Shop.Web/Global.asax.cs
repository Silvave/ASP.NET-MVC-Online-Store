namespace Shop.Web
{
    using AutoMapper;
    using Models;
    using ViewModels.Account;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.IO;

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
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(dest => dest.ProfilePicture,
                            mo => mo.MapFrom(src => FileToBytes(src.ProfilePicture)));
            });
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
