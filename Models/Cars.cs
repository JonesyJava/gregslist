using System;
using System.ComponentModel.DataAnnotations;

namespace gregslist.Models
{

    public class Car
    {
        public Car(string make, string model, int year, string color, int price, string imgUrl, string description)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            Price = price;
            ImgUrl = imgUrl;
            Description = description;
        }
        public Car()
        {

        }

        [Required]
        [MinLength(3)]
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public string ImgUrl { get; set; }

        public int Id { get; set; }
    }
}