using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutomobileAPI.Repository.Models
{
    [Table("CarMake")]
    public partial class CarMake
    {
        public CarMake()
        {
            CarModels = new HashSet<CarModel>();
        }

        [Key]
        [Column("CarMakeID")]
        public int CarMakeId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string CarMakeName { get; set; } = null!;
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

        [InverseProperty(nameof(CarModel.CarMake))]
        public virtual ICollection<CarModel> CarModels { get; set; }
    }
}
