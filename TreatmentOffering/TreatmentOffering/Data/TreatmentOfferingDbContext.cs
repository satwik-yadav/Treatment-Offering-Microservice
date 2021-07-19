using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TreatmentOffering.Models;

namespace TreatmentOffering.Data
{
    public class TreatmentOfferingDbContext : DbContext
    {

        public TreatmentOfferingDbContext(DbContextOptions options) : base(options)
        {
        }
        

        public  DbSet<AilmentCategory> AilmentCategories { get; set; }
        public  DbSet<PackageDetail> PackageDetails { get; set; }
        public  DbSet<SpecialistDetail> SpecialistDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }



    }
}
