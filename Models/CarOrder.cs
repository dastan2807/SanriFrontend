using SanriJP.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SanriJP.API.Models
{
    public class CarOrder
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(ClientId))]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        
        [ForeignKey(nameof(AuctionId))]
        public int AuctionId { get; set; }
        public virtual Auction Auction { get; set; }

        public string LotNumber { get; set; }
        public string CarModel { get; set; }
        public string VINNumber { get; set; }
        public string Year { get; set; }
        public int Price { get; set; }
        public int Price10Percent { get; set; }
        public int Recycle { get; set; }
        public int AuctionFees { get; set; } //Racsatsu
        public int Transport { get; set; } //Rikso
        public int FOB { get; set; }
        public int Amount { get; set; }
        public int TransportationCommission { get; set; }
        public byte Parking { get; set; }
        public bool CarNumber { get; set; }
        public int Total { get; set; }
        public int Total_FOB { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateCarOrderRequest
    {
        public int ClientId { get; set; }
        public int AuctionId { get; set; }
        public string LotNumber { get; set; }
        public string CarModel { get; set; }
        public string VINNumber { get; set; }
        public string Year { get; set; }
        public int Price { get; set; }
        public int Recycle { get; set; }
        public int AuctionFees { get; set; } //Racsatsu
        public int Transport { get; set; } //Rikso
        public int FOB { get; set; }
        public int Amount { get; set; }
        public int TransportationCommission { get; set; }
        public byte Parking { get; set; }
        public bool CarNumber { get; set; }
        public int Total { get; set; }
        public int Total_FOB { get; set; }
    }
}
