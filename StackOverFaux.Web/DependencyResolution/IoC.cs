using StructureMap;
using StackOverFaux.Data.Abstract;
using StackOverFaux.Data.Concrete;
namespace StackOverFaux.Web {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IBadgeRepository>().Use<SqlBadgeRepository>();
                            x.For<IPostRepository>().Use<SqlPostRepository>();
                            x.For<ITagRepository>().Use<SqlTagRepository>();
                            x.For<IUserRepository>().Use<SqlUserRepository>();
                        });
            return ObjectFactory.Container;
        }
    }
}