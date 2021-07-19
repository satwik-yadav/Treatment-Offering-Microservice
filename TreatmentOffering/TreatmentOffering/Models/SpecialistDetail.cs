using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreatmentOffering.Models
{
    public class SpecialistDetail
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int ExperienceInYears { get; set; }
        public long ContactNumber { get; set; }

        [ForeignKey("Ailment")]
        public string AreaOfExpertise { get; set; }  
        public AilmentCategory AilmentCategory { get; set; }
        
    }
}
