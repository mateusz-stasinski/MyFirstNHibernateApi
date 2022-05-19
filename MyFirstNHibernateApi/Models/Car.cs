using System;
using System.Collections.Generic;

namespace MyFirstNHibernateApi.Models
{
    public class Car
    {
        public virtual Guid Id { get; set; }
        public virtual int Model { get; set; }
        public virtual int YearOfProduction { get; set; }
        public virtual string RegistrationNumber { get; set; }

        public virtual ISet<CarModel> CarModels { get; set; }
    }
}
