using System;

namespace MyFirstNHibernateApi.Dto
{
    public class AddNewCarRequest
    {
        public int Model { get; set; }
        public int YearOfProduction { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
