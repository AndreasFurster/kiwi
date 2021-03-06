﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Lisa.Kiwi.WebApi
{
    [Table("Vehicles")]
    public class VehicleData
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string NumberPlate { get; set; }
        public string Color { get; set; }
        public string AdditionalFeatures { get; set; }
    }
}