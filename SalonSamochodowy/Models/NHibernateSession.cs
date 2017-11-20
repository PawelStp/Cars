using NHibernate;
using NHibernate.Cfg;
using System.Reflection;
using System.Web;

namespace SalonSamochodowy.Models
{
    public class NHibernateSession 
    {
        public static NHibernate.ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            configuration.AddFile(HttpContext.Current.Server.MapPath(@"~\Models\Dzial.hbm.xml"));
            configuration.AddFile(HttpContext.Current.Server.MapPath(@"~\Models\Pracownik.hbm.xml"));
            configuration.AddFile(HttpContext.Current.Server.MapPath(@"~\Models\Pracownik_personalia.hbm.xml"));
            configuration.AddFile(HttpContext.Current.Server.MapPath(@"~\Models\Samochod.hbm.xml"));
            configuration.AddFile(HttpContext.Current.Server.MapPath(@"~\Models\Zakup.hbm.xml"));
            configuration.AddFile(HttpContext.Current.Server.MapPath(@"~\Models\Klient.hbm.xml"));
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}