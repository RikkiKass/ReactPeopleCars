using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReactPeopleCars.Data;


namespace ReactPeopleCars.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly string _connectionString;
        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        [Route("getcars")]
        public List<Car> GetCars(int id)
        {
            var repo = new PeopleCarsRepository(_connectionString);
            return repo.GetCars(id);
        }
     
        [Route("getall")]
        public List<Person> GetPeople()
        {
            var repo = new PeopleCarsRepository(_connectionString);
            return repo.GetAll();
        }
        [Route("addperson")]
        [HttpPost]
        public void AddPerson(Person person)
        {
            var repo = new PeopleCarsRepository(_connectionString);
            repo.AddPerson(person);
        }
        [Route("getperson")]
        public Person GetPerson(int id)
        {
            var repo = new PeopleCarsRepository(_connectionString);
            return repo.GetPerson(id);
        }
       

        [Route("addcarforperson")]
        [HttpPost]
        public void AddCarForPerson(Car car)
        {
            var repo = new PeopleCarsRepository(_connectionString);
            repo.AddCar(car);
        }
        [Route("deletecars")]
        [HttpPost]
        public void DeleteCars(List<Car>cars)
        {
            var repo = new PeopleCarsRepository(_connectionString);
            repo.DeleteCars(cars);
        }

    }
}
