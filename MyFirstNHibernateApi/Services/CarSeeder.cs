using MyFirstNHibernateApi.Models;

namespace MyFirstNHibernateApi.Services
{
    public class CarSeeder
    {
        private readonly SessionFactory _sessionFactory;

        public CarSeeder(SessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void Seed()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    //var car = new Car()
                    //{
                       
                    //};
                    //session.Save(car);
                    //tx.Commit();
                }
            }
        }
    }
}
