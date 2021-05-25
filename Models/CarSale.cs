using SanriJP.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SanriJP.API.Models
{
    public class CarSale
    {
        [Key]
        public int Id { get; set; }
        public int OwnerClientId { get; set; }
        public int AuctionId { get; set; }
        public string CarModel { get; set; }
        public string VINNumber { get; set; }
        public int Price { get; set; }
        public int Price10Percent { get; set; }
        public int Recycle { get; set; }
        public int AuctionFees { get; set; } //Racsatsu
        public int SalesFees { get; set; }
        public bool Status { get; set; }
        public int Total { get; set; }
        public DateTime CreatedAt { get; set; }
        
        [ForeignKey(nameof(OwnerClientId))]
        public virtual Client OwnerClient { get; set; }

        [ForeignKey(nameof(AuctionId))]
        public virtual Auction Auction { get; set; }
    }

    public class CreateCarSaleRequest
    {
        public int OwnerId { get; set; }
        public int AuctionId { get; set; }
        public string CarModel { get; set; }
        public string VINNumber { get; set; }
        public int Price { get; set; }
        public int Recycle { get; set; }
        public int AuctionFees { get; set; } //Racsatsu
        public int SalesFees { get; set; }
        public bool Status { get; set; }
        public int Total { get; set; }

    }
}
