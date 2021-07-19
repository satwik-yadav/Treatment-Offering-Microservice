using TreatmentOffering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TreatmentOffering.Data;
using System.Threading.Tasks;
namespace TreatmentOffering.Repository
{
    public class OfferingRepo : IOfferingRepo
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(OfferingRepo));
        private  TreatmentOfferingDbContext _context;
        public OfferingRepo(TreatmentOfferingDbContext context)
        {
            _context = context;
            if (_context.PackageDetails.Any())
            {
                return;
            }

            _context.AilmentCategories.AddRange(
                new AilmentCategory { AilmentId = 1, Ailment = "Orthopaedics" },
                new AilmentCategory { AilmentId = 2, Ailment = "Urology" }
             );
            _context.PackageDetails.AddRange(
                new PackageDetail { PackageId = 1, Ailment = "Orthopaedics", TreatmentPackageName = "Package 1", TestDetails = "OPT1, OPT2", Cost = 2500, TreatmentDuration = 4 },
                new PackageDetail { PackageId = 2, Ailment = "Orthopaedics", TreatmentPackageName = "Package 2", TestDetails = "OPT3,OPT4", Cost = 3000, TreatmentDuration = 6 },
                new PackageDetail { PackageId = 3, Ailment ="Urology", TreatmentPackageName = "Package 1", TestDetails = "UPT1,UPT2", Cost = 4000, TreatmentDuration = 4 },
                new PackageDetail { PackageId = 4, Ailment = "Urology", TreatmentPackageName = "Package 2", TestDetails = "UPT3,UPT4", Cost = 5000, TreatmentDuration = 6 }
            );
            _context.SpecialistDetails.AddRange(
                new SpecialistDetail { Id = 1, Name = "Shriny", ExperienceInYears = 4, ContactNumber = 8514235879, AreaOfExpertise = "Orthopaedics" },
                new SpecialistDetail { Id = 2, Name = "Joey", ExperienceInYears = 13, ContactNumber = 9875214000, AreaOfExpertise = "Orthopaedics" },
                new SpecialistDetail { Id = 3, Name = "Rachel", ExperienceInYears = 15, ContactNumber = 6358290001, AreaOfExpertise = "Urology" },
                new SpecialistDetail { Id = 4, Name = "Chandler", ExperienceInYears = 2, ContactNumber = 9965231470, AreaOfExpertise = "Urology" }
            );
           _context.SaveChanges();

        }


        public List<PackageDetail> GetTreatmentPackages()
        {
            List<PackageDetail> details = new List<PackageDetail>();
            try
            {
                details =  _context.PackageDetails.ToList();
                if (details == null)
                    return null;
            }
            catch (Exception exception)
            {
                _log4net.Error(exception.Message);

                return null;
            }
            _log4net.Info("Package details is fetched  Successfully");
            return details;
        }
        public List<PackageDetail> GetPackagesByName(string packageName)
        {
            List<PackageDetail> detailsByNames = new List<PackageDetail>();
            try
            {
                detailsByNames =  _context.PackageDetails.Where
                    (detail => detail.TreatmentPackageName == packageName).ToList();
                if(detailsByNames==null)
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                _log4net.Error(exception.Message);

            }
            _log4net.Info("Package Name is fetched  Successfully");
             return detailsByNames;
        }

        public List<SpecialistDetail> GetSpecialistDetails()
        {
            List<SpecialistDetail> specialistDetails = new List<SpecialistDetail>();
            try
            {
                specialistDetails = _context.SpecialistDetails.ToList();

                if (specialistDetails == null)
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                _log4net.Error(exception.Message);

                return null;
            }
             _log4net.Info("Specialist details is fetched  Successfully");
            return specialistDetails;   
            }
       }
}
