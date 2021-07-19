using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TreatmentOffering.Models
{
    public class PackageDetail
    {
        [Key]
        public int PackageId { get; set; }
        [ForeignKey("Ailment")]
        public string Ailment{ get; set; }
        public string TreatmentPackageName { get; set; }
        public string TestDetails { get; set; }
        public int Cost { get; set; }
        public int TreatmentDuration { get; set; }
        public AilmentCategory AilmentCategory { get; set; }
    }
}
