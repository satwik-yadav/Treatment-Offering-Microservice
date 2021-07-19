using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatmentOffering.Data;
using TreatmentOffering.Models;
using TreatmentOffering.Repository;

namespace TreatmentOffering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferingController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(OfferingController));
        IOfferingRepo _repo;
        public OfferingController(IOfferingRepo repo)
        {
            _repo = repo;
        }
        //GET : api/Offering/IPTreatmentPackages
        [HttpGet]
        [Route("IpTreatmentPackages")]
        public ActionResult<PackageDetail> IpTreatmentPackages()
        {
            _log4net.Info("Get Treatment Packages Service called..");

            var treatmentPackages =  _repo.GetTreatmentPackages();

            if (treatmentPackages.Count == 0)
            {
                return BadRequest("No Details Found");
            }

            return Ok(treatmentPackages);
        }
        //GET : api/Offering/IPTreatmentPackagesByName
        [HttpGet]
        [Route("IpTreatmentPackagesByName/{packageName}")]
        public ActionResult<PackageDetail> IpTreatmentPackagesByName(string packageName)
        {
            var treatmentDetail =  _repo.GetPackagesByName(packageName);
            if (treatmentDetail == null)
            {
                return BadRequest("Package Name Not Found");
            }
            return Ok(treatmentDetail);
        }
        //GET : api/Offering/Specialists
        [HttpGet]
        [Route("Specialists")]
        public ActionResult<SpecialistDetail> Specialists()
        {
            _log4net.Info("Get Specialist Details called..");

            var specialist = _repo.GetSpecialistDetails();

            if (specialist.Count == 0)
            {
                return BadRequest("No Details Found");
            }

            return Ok(specialist);
        }
    }
}
