using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatmentOffering.Controllers;
using TreatmentOffering.Models;

namespace TreatmentOffering.Repository
{
    public interface IOfferingRepo
    {
        public List<PackageDetail> GetTreatmentPackages();
        public List<PackageDetail> GetPackagesByName(string packageName);
        public List<SpecialistDetail> GetSpecialistDetails();

    }

}

