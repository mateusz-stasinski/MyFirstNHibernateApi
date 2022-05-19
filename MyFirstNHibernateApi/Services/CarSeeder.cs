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
                    var car = new Car()
                    {
                        Manufacturer = "BMW",
                        Model = "seria 3 E90",
                        YearOfProduction = 2005,
                        RegistrationNumber = "CBY 1111"
                    };
                    session.Save(car);
                    tx.Commit();
                }
            }
        }
    }
}
