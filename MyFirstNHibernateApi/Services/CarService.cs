using MyFirstNHibernateApi.Dto;
using MyFirstNHibernateApi.Models;
using System;
using System.Linq;

namespace MyFirstNHibernateApi.Services
{
    public class CarService
    {
        private readonly SessionFactory _sessionFactory;

        public CarService(SessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public CarManufacturerDto GetCarManufacturer(int id)
        {
            CarManufacturerDto carManufacturerDto = new CarManufacturerDto();

            using (var session = _sessionFactory.OpenSession())
            {
                var carManufacturer = session.Query<CarManufacturer>().SingleOrDefault(x => x.Id == id);
                carManufacturerDto.Id = carManufacturer.Id;
                carManufacturerDto.Name = carManufacturer.Name;
            }
            return carManufacturerDto;
        }

        public int AddNewCarManufacturer(AddNewCarManufacturerRequest request)
        {
            var manufacturer = new CarManufacturer()
            {
                Name = request.Name
            };

            using (var session = _sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(manufacturer);
                    tx.Commit();
                    return manufacturer.Id;
                }
            }
        }
        public void UpdateCarManufacturer(int id, UpdateCarManufacturerRequest request)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var carManufacturer = session.Query<CarManufacturer>().SingleOrDefault(x => x.Id == id);
                carManufacturer.Name = request.Name;
                using (var tx = session.BeginTransaction())
                {
                    session.Update(carManufacturer);
                    tx.Commit();
                }
            }
        }

        public int AddNewCarModel(AddNewCarModelRequest request)
        {
            var model = new CarModel()
            {
                Manufacturer = request.ManufacturerId,
                Name = request.Name
            };

            using (var session = _sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(model);
                    tx.Commit();
                    return model.Id;
                }
            }
        }

        public CarModelDto GetCarModel(int id)
        {
            var modelDto = new CarModelDto();
            using (var session = _sessionFactory.OpenSession())
            {
                var model = session.Query<CarModel>().SingleOrDefault(x => x.Id == id);
                modelDto.Id = model.Id;
                modelDto.Name = model.Name;
                //modelDto.Manufacturer = model.CarManufacturer.Name;
            }
            return modelDto;
        }

        public Guid AddNewCar(AddNewCarRequest request)
        {
            var car = new Car()
            {
                Model = request.Model,
                YearOfProduction = request.YearOfProduction,
                RegistrationNumber = request.RegistrationNumber
            };

            using (var session = _sessionFactory.OpenSession())
            {
                using(var tx = session.BeginTransaction())
                {
                    session.Save(car);
                    tx.Commit();
                    return car.Id;
                }
            }
        }

        
    }
}
