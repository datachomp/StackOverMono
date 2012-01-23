using StructureMap;
using StackOverFaux.Data.Abstract;
using StackOverFaux.Data.Concrete;
using System.Configuration;
namespace StackOverFaux.Web {
    public static class IoC {
        public static IContainer Initialize() {

            string connectionString = ConfigurationManager.ConnectionStrings["SoFConnStr"].ConnectionString.ToString();

            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IBadgeRepository>().Use<SqlBadgeRepository>().Ctor<string>(connectionString);
                            x.For<IPostRepository>().Use<SqlPostRepository>().Ctor<string>(connectionString);
                            x.For<ITagRepository>().Use<SqlTagRepository>().Ctor<string>(connectionString);
                            //x.For<IUserRepository>().Use<SqlUserRepository>();
                            x.For<IUserRepository>().Use<SqlUserRepository>().Ctor<string>(connectionString); 
                        });
            return ObjectFactory.Container;
        }
    }
}