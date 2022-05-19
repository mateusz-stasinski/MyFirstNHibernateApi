namespace MyFirstNHibernateApi.Services
{
    public class CarService
    {
        private readonly SessionFactory _sessionFactory;

        public CarService(SessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }
    }
}
