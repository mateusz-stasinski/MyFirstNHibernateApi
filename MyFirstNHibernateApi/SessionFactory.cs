using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;

namespace MyFirstNHibernateApi
{
    public class SessionFactory
    {
        public readonly ISessionFactory _sessionFactory;

        public SessionFactory()
        {
            var configuration = new Configuration();
            var assembly = configuration.DataBaseIntegration(c =>
            {
                c.Dialect<MsSql2012Dialect>();

                c.ConnectionString = "SERVER=(localdb)\\MSSQLLocalDB;Database=NHibernateExample;Integrated security=SSPI";
            });

            configuration.AddAssembly(typeof(SessionFactory).Assembly);

            _sessionFactory = configuration.BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            var session = _sessionFactory.OpenSession();
            return session;
        }
    }
}
