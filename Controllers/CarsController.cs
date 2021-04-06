using System.Collections.Generic;
using gregslist.db;
using gregslist.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                return Ok(FakeDB.Cars);
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
                FakeDB.Cars.Add(newCar);
                return Ok(newCar);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{carId}")]
        public ActionResult<Car> GetCarById(string carId)
        {
            try
            {
                Car carFound = FakeDB.Cars.Find(c => c.Id == carId);
                if (carFound == null)
                {
                    throw new System.Exception("Car does not exist");
                }
                return Ok(carFound);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteCar(string id)
        {
            try
            {
                Car carToRemove = FakeDB.Cars.Find(c => c.Id == id);
                if (FakeDB.Cars.Remove(carToRemove))
                {
                    return Ok("Car Deleted");
                }
                else
                {
                    throw new System.Exception("This car does not exist");
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Car> EditCar(string id, Car updatedCar)
        {
            try
            {
                Car carFound = FakeDB.Cars.Find(c => c.Id == id);
                if (carFound == null)
                {
                    throw new System.Exception("Car does not exist");
                }
                carFound.Make = updatedCar.Make;
                carFound.Model = updatedCar.Model;
                carFound.Year = updatedCar.Year;
                carFound.Color = updatedCar.Color;
                carFound.Description = updatedCar.Description;
                carFound.ImgUrl = updatedCar.ImgUrl;
                return Ok(carFound);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}