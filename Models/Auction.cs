using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SanriJP.API.Models
{
    public class Auction
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParkingPrice1 { get; set; }
        public string ParkingPrice2 { get; set; }
        public string ParkingPrice3 { get; set; }
        public string ParkingPrice4 { get; set; }
    }
}
