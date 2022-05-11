using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ReactPeopleCars.Data
{
    public class PeopleCarsRepository
    {
        private string _connectionString;
        public PeopleCarsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Person> GetAll()
        {
            using var context = new PeopleCarsDataContext(_connectionString);
            return context.People.Include(p => p.Cars).ToList();
        }
        public void AddPerson(Person person)
        {
            using var context = new PeopleCarsDataContext(_connectionString);
            context.People.Add(person);
            context.SaveChanges();
        }
        public Person GetPerson(int id)
        {
            using var context = new PeopleCarsDataContext(_connectionString);
            return context.People.FirstOrDefault(p => p.Id == id);
        }
        public List<Car> GetCars(int id)
        {
            using var context = new PeopleCarsDataContext(_connectionString);
            return context.Cars.Where(c => c.PersonId==id).ToList();
        }
        public void AddCar(Car car)
        {
            using var context = new PeopleCarsDataContext(_connectionString);
            context.Cars.Add(car);
            context.SaveChanges();
        }
        public void DeleteCars(List<Car> cars)
        {
            using var context = new PeopleCarsDataContext(_connectionString);
            context.Cars.RemoveRange(cars);
            context.SaveChanges();

        }
    }
}