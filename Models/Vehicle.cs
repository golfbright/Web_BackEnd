using Microsoft.AspNetCore.Mvc;
using System;

namespace TMSAPI.Models
{
    public partial class Vehicle 
    {
        public Vehicle(string vehicleType,string vehicleBrand,string vehiclePlate,string vehicleStatus )
        {
            VehicleType = vehicleType;  
            VehicleBrand = vehicleBrand;
            VehiclePlate = vehiclePlate;
            VehicleStatus = vehicleStatus;
        }

        public void Update(string vehicleType, string vehicleBrand, string vehiclePlate, string vehicleStatus)
        {
            VehicleType = vehicleType;
            VehicleBrand = vehicleBrand;
            VehiclePlate = vehiclePlate;
            VehicleStatus = vehicleStatus;
        }
        public int Id { get; set; }
        public string VehicleType { get; set;}
        public string VehicleBrand { get; set;}
        public string VehiclePlate { get; set;}
        public string VehicleStatus { get; set;}   
    }
}
