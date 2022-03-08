using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutomobileAPI.Repository.Models
{
    [Keyless]
    public partial class VwCarsForSale
    {
        [Column("CarForSaleID")]
        public int CarForSaleId { get; set; }
        [Column("CarModelID")]
        public int? CarModelId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string CarMakeName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string CarModelName { get; set; } = null!;
        public int? Miles { get; set; }
        [Column(TypeName = "decimal(18, 1)")]
        public decimal? Ratings { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? ZipCode { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? SellerName { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? SellerContactDetails { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Color { get; set; }
        public string? Image { get; set; }
    }
}
