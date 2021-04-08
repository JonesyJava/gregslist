using System;
using System.Collections.Generic;
using cars.Repositories;
using gregslist.Models;

namespace cars.Services
{
    public class CarsService
    {
        private readonly CarsRepository _repo;

        public CarsService(CarsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Car> Get()
        {
            return _repo.Get();
        }

        internal Car Get(int carId)
        {
            Car car = _repo.Get(carId);
            if (car == null)
            {
                throw new Exception("Invalid Car ID");
            }
            return car;
        }

        internal object Delete(int carId)
        {
            Car original = Get(carId);
            _repo.Delete(carId);
            return original;
        }

        internal Car Create(Car newCar)
        {
            return _repo.Create(newCar);
        }

        internal Car Edit(Car updatedCar)
        {
            Car original = Get(updatedCar.Id);
            original.Make = updatedCar.Make != null ? updatedCar.Make : original.Make;
            original.Model = updatedCar.Model != null ? updatedCar.Model : original.Model;
            original.Description = updatedCar.Description != null ? updatedCar.Description : original.Description;
            original.Price = updatedCar.Price != null ? updatedCar.Price : original.Price;
            original.Year = updatedCar.Year > 0 ? updatedCar.Year : original.Year;
            original.Color = updatedCar.Color != null ? updatedCar.Color : original.Color;
            original.ImgUrl = updatedCar.ImgUrl != null ? updatedCar.ImgUrl : original.ImgUrl;


            return _repo.Edit(original);
        }
    }
}