using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SanriJP.API.Models;
using System;

namespace SanriJP.API.DataContext
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Manager = "Manager";
    }
    public static class DataSeed
    {
        private static ModelBuilder _modelBuilder;
        public static void DBInitializer(this ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
            CrеаteAdmin();
            CrеаteManager();
            CreateEntities();
        }

        private static void CreateEntities()
        {
            _modelBuilder.Entity<Auction>().HasData(new Auction
            {
                Id = 1,
                Name = "USS Osaka",
                ParkingPrice1 = "11000",
                ParkingPrice2 = "12000",
                ParkingPrice3 = "11000",
                ParkingPrice4 = "13000"
            });

            _modelBuilder.Entity<CarModel>().HasData(new CarModel
            {
                Id = 1,
                Name = "Mersedes Benz"
            },
            new CarModel
            {
                Id = 2,
                Name = "Audi"
            },
            new CarModel
            {
                Id = 3,
                Name = "Nissan"
            });

            _modelBuilder.Entity<Client>().HasData(new Client
            {
                Id = 1,
                FullName = "Rysbekov Chekhton",
                Country = "Kyrgyzstan",
                Email = "qweyn.qwe@gmail.com",
                PhoneNumber = "996996996996",
                Service = "default",
                AtWhatPrice = "default",
                SizeFOB = "2000",
                Login = "CHEKHTON",
                Password = "123qwe",
                Confirm = false,
                CreatedAt = DateTime.UtcNow
            });
            
            _modelBuilder.Entity<CarOrder>().HasData(new CarOrder
            {
                Id = 1,
                ClientId = 1,
                AuctionId = 1,
                LotNumber = "00521",
                CarModel = "Mersedes Benz",
                VINNumber = "q1w2e3",
                Year = "2020",
                Price = 145000,
                Price10Percent = 14500,
                AuctionFees = 7700,
                Recycle = 11550,
                Transport = 20000,
                FOB = 65000,
                Amount = 150000,
                TransportationCommission = 19000,
                Parking = 1,
                CarNumber = false,
                Total = 198750,
                Total_FOB = 380000,
                CreatedAt = DateTime.UtcNow
            });
        }

        private static void CrеаteAdmin()
        {
            var adminLogin = "ADMIN";
            var adminPass = "Admin123!@#";
            var adminFullName = "Adminio";

            _modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                FullName = adminFullName,
                Login = adminLogin,
                Password = adminPass,
                CreatedAt = DateTime.UtcNow,
                Role = Roles.Admin
            });

            //var hasher = new PasswordHasher<Employee>();
           
        }
        private static void CrеаteManager()
        {
            var managerLogin = "MANAGER";
            var managerPass = "Manager123!@#";
            var managerFullName = "Managereto";

            _modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                FullName = managerFullName,
                Login = managerLogin,
                Password = managerPass,
                CreatedAt = DateTime.UtcNow,
                Role = Roles.Manager
            });
        }
    }
}
