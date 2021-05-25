using SanriJP.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SanriJP.API.Models
{
    public class CarResale
    {
        [Key]
        public int Id { get; set; }
        public int? OwnerClientId { get; set; }
        public int CarOrderId { get; set; }
        public string StartingPrice { get; set; }
        public int? NewClientId { get; set; }
        public string SalePrice { get; set; }
        public string Income { get; set; }
        public DateTime CreatedAt { get; set; }
        
        [ForeignKey(nameof(OwnerClientId))]
        public virtual Client OwnerClient { get; set; }
        [ForeignKey(nameof(NewClientId))]
        public virtual Client NewClient { get; set; }
        [ForeignKey(nameof(CarOrderId))]
        public virtual CarOrder CarOrder { get; set; }
    }

    public class CreateCarResaleRequest
    {
        public int OwnerClientId { get; set; }
        public int CarOrderId { get; set; }
        public string StartingPrice { get; set; }
        public int NewClientId { get; set; }
        public string SalePrice { get; set; }
        public string Income { get; set; }
    }
}
