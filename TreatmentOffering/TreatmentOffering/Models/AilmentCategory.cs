using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
namespace TreatmentOffering.Models
{
    public class AilmentCategory
    {
        [Key]
        public int AilmentId { get; set; }
        public string Ailment { get; set; }
    }
}
