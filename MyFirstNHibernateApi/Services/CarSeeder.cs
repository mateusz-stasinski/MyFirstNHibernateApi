using MyFirstNHibernateApi.Models;
using System.Collections.Generic;
using System.Linq;

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
                if (!session.Query<CarManufacturer>().Any())
                {
                    using (var tx = session.BeginTransaction())
                    {
                        var manufacturers = new HashSet<CarManufacturer>()
                        {
                            new CarManufacturer()
                            {
                                Name = "Toyota",
                                CarModels = new HashSet<CarModel>()
                                {
                                    new CarModel()
                                    {
                                        Name = "Corolla"
                                    },

                                    new CarModel()
                                    {
                                        Name = "Avensis"
                                    }
                                }
                            },

                            new CarManufacturer()
                            {
                                Name = "Volkswagen",
                                CarModels = new HashSet<CarModel>()
                                {
                                    new CarModel()
                                    {
                                        Name = "Golf"
                                    },

                                    new CarModel()
                                    {
                                        Name = "Pasat"
                                    }
                                }
                            }
                        };

                        foreach(var manufacturer in manufacturers)
                        {
                            session.Save(manufacturer);
                        }
                        
                        tx.Commit();
                    }
                }
            }
        }
    }
}
