﻿using System.Collections.Generic;

namespace MyFirstNHibernateApi.Models
{
    public class CarModel
    {
        public virtual int Id { get; set; }
        public virtual int Manufacturer { get; set; }
        public virtual string Name { get; set; }

        public virtual ISet<CarManufacturer> CarManufacturers { get; set; } = new HashSet<CarManufacturer>();
    }
}
