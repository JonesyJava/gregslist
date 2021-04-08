using System;
using System.Collections.Generic;
using System.Data;
using gregslist.Models;
using Dapper;

namespace cars.Repositories
{
    public class CarsRepository
    {
        private readonly IDbConnection _db;

        public CarsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Car> Get()
        {
            string sql = "SELECT * FROM cars;";
            return _db.Query<Car>(sql);
        }

        internal Car Get(int carId)
        {
            string sql = "SELECT * FROM cars WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Car>(sql, new { carId });
        }

        internal void Delete(int carId)
        {
            string sql = "DELETE FROM cars WHERE id = @Id;";
            _db.Execute(sql, new { carId });
            return;
        }

        internal Car Create(Car newCar)
        {
            string sql = @"
            INSERT INTO cars
            (make, model, description, price)
            VALUES
            (@Make, @Model, @Description, @Price);
            SELECT LAST_INSERT_ID();";
            int carId = _db.ExecuteScalar<int>(sql, newCar);
            newCar.Id = carId;
            return newCar;
        }

        internal Car Edit(Car carToEdit)
        {
            string sql = @"
            UPDATE cars
            SET
                make = @Make,
                model = @Model,
                description = @Description,
                price = @Price,
                // color = @Color,
                // imgUrl = @ImgUrl
            WHERE id = @Id;
            SELECT * FROM cars WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Car>(sql, carToEdit);
        }
    }
}