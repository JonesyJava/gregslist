using System.Collections.Generic;
using gregslist.Models;
using Microsoft.AspNetCore.Mvc;
using cars.Services;

namespace gregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarsService _service;

        public CarsController(CarsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                // return Ok(FakeDB.Cars);
                return Ok(_service.Get());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                return Ok(_service.Create(newCar));
                // // FakeDB.Cars.Add(newCar);
                // return Ok(newCar);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{carId}")] // GET by ID
        public ActionResult<Car> GetCarById(int carId)
        {
            try
            {
                return Ok(_service.Get(carId));
                // // Car carFound = FakeDB.Cars.Find(c => c.Id == carId);
                // if (carFound == null)
                // {
                //     throw new System.Exception("Car does not exist");
                // }
                // return Ok(carFound);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Car> DeleteCar(int carId)
        {
            try
            {
                return Ok(_service.Delete(carId));
                // Car carToRemove = FakeDB.Cars.Find(c => c.Id == id);
                // if (FakeDB.Cars.Remove(carToRemove))
                // {
                //     return Ok("Car Deleted");
                // }
                // else
                // {
                //     throw new System.Exception("This car does not exist");
                // }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Car> Edit(int carId, Car updatedCar)
        {
            try
            {
                updatedCar.Id = carId;
                return Ok(_service.Edit(updatedCar));
                // Car carFound = FakeDB.Cars.Find(c => c.Id == id);
                // if (carFound == null)
                // {
                //     throw new System.Exception("Car does not exist");
                // }
                // carFound.Make = updatedCar.Make;
                // carFound.Model = updatedCar.Model;
                // carFound.Year = updatedCar.Year;
                // carFound.Color = updatedCar.Color;
                // carFound.Description = updatedCar.Description;
                // carFound.ImgUrl = updatedCar.ImgUrl;
                // return Ok(carFound);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}