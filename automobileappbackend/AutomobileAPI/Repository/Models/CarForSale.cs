using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutomobileAPI.Repository.Models
{
    [Table("CarForSale")]
    public partial class CarForSale
    {
        [Key]
        [Column("CarForSaleID")]
        public int CarForSaleId { get; set; }
        [Column("CarModelID")]
        public int? CarModelId { get; set; }
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
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdatedDate { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? LastUpdatedBy { get; set; }

        [ForeignKey(nameof(CarModelId))]
        [InverseProperty("CarForSales")]
        public virtual CarModel? CarModel { get; set; }
    }
}
