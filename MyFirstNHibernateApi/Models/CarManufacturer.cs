using System.Collections.Generic;

namespace MyFirstNHibernateApi.Models
{
    public class CarManufacturer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual ISet<CarModel> CarModels { get; set; } = new HashSet<CarModel>();
    }
}
