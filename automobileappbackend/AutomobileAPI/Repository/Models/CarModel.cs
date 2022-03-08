using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutomobileAPI.Repository.Models
{
    [Table("CarModel")]
    public partial class CarModel
    {
        public CarModel()
        {
            CarForSales = new HashSet<CarForSale>();
        }

        [Key]
        [Column("CarModelID")]
        public int CarModelId { get; set; }
        [Column("CarMakeID")]
        public int? CarMakeId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string CarModelName { get; set; } = null!;
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

        [ForeignKey(nameof(CarMakeId))]
        [InverseProperty("CarModels")]
        public virtual CarMake? CarMake { get; set; }
        [InverseProperty(nameof(CarForSale.CarModel))]
        public virtual ICollection<CarForSale> CarForSales { get; set; }
    }
}
