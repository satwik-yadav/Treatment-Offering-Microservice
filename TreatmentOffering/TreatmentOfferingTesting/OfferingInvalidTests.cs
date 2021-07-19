using NUnit.Framework;
using Moq;
using TreatmentOffering.Controllers;
using TreatmentOffering.Data;
using TreatmentOffering.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TreatmentOffering.Repository;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;

namespace TreatmentOfferingTesting
{
    class OfferingInvalidTests
    {
        PackageDetail package = new PackageDetail();
        List<PackageDetail> packageDetails = new List<PackageDetail>();
        SpecialistDetail specialistDetail = new SpecialistDetail();
        List<SpecialistDetail> specialists = new List<SpecialistDetail>();
        Mock<IOfferingRepo> mockOffering;
        OfferingRepo offeringRepo;

        [SetUp]
        public void Setup()
        {
            mockOffering = new Mock<IOfferingRepo>();
            packageDetails = null;
            specialists = null;
            var option = new DbContextOptionsBuilder<TreatmentOfferingDbContext>().UseInMemoryDatabase(databaseName: "TreatmentOffering").Options;
            var context = new TreatmentOfferingDbContext(option);
            offeringRepo = new OfferingRepo(context);

        }
        [Test]
        public void GetTreatmentPackages_InValidData()
        {
            mockOffering.Setup(x => x.GetTreatmentPackages()).Returns(new List<PackageDetail>());
            var result = offeringRepo.GetTreatmentPackages();
            var a = mockOffering.Object.GetTreatmentPackages();
            Assert.AreNotEqual(a, result);
        }
        [TestCase("Package 3")]
        public void GetPackagesByName_InValidData(string packageName)
        {
            mockOffering.Setup(x => x.GetPackagesByName(packageName)).Returns(new List<PackageDetail>()
            {
               new PackageDetail { PackageId = 1, Ailment = "Orthopaedics", TreatmentPackageName = "Package 1", TestDetails = "OPT1, OPT2", Cost = 2500, TreatmentDuration = 4 },
               new PackageDetail { PackageId = 2, Ailment = "Orthopaedics", TreatmentPackageName = "Package 2", TestDetails = "OPT3,OPT4", Cost = 3000, TreatmentDuration = 6 },
               new PackageDetail { PackageId = 3, Ailment ="Urology", TreatmentPackageName = "Package 1", TestDetails = "UPT1,UPT2", Cost = 4000, TreatmentDuration = 4 },
               new PackageDetail { PackageId = 4, Ailment = "Urology", TreatmentPackageName = "Package 2", TestDetails = "UPT3,UPT4", Cost = 5000, TreatmentDuration =6 }
             });
            var result = offeringRepo.GetPackagesByName(packageName);
            Assert.AreEqual(0, result.Count);
        }
        [Test]
        public void GetSpecialistDetails_InvalidData()
        {
            mockOffering.Setup(x => x.GetSpecialistDetails()).Returns(new List<SpecialistDetail>());
            var result = offeringRepo.GetSpecialistDetails();
            List<SpecialistDetail> a = mockOffering.Object.GetSpecialistDetails();
            Assert.AreNotEqual(a.Count, result.Count);
        }
        [Test]
        public void IpTreatmentPackages_InvalidData()
        {
            mockOffering.Setup(x => x.GetTreatmentPackages()).Returns(new List<PackageDetail>());
            List<SpecialistDetail> a = mockOffering.Object.GetSpecialistDetails();
            OfferingController pc = new OfferingController(mockOffering.Object);
            var result = pc.IpTreatmentPackages() as ActionResult<PackageDetail>;
            var result1 = pc.IpTreatmentPackages();
            Assert.AreNotEqual(result, result1);
        }
        [TestCase("Package 3")]
        public void PackagesByName_InvalidData(string packageName)
        {
            mockOffering.Setup(x => x.GetPackagesByName(packageName)).Returns(new List<PackageDetail>()
            {
               new PackageDetail { PackageId = 1, Ailment = "Orthopaedics", TreatmentPackageName = "Package 1", TestDetails = "OPT1, OPT2", Cost = 2500, TreatmentDuration = 4 },
               new PackageDetail { PackageId = 2, Ailment = "Orthopaedics", TreatmentPackageName = "Package 2", TestDetails = "OPT3,OPT4", Cost = 3000, TreatmentDuration = 6 },
               new PackageDetail { PackageId = 3, Ailment ="Urology", TreatmentPackageName = "Package 1", TestDetails = "UPT1,UPT2", Cost = 4000, TreatmentDuration = 4 },
               new PackageDetail { PackageId = 4, Ailment = "Urology", TreatmentPackageName = "Package 2", TestDetails = "UPT3,UPT4", Cost = 5000, TreatmentDuration =6 }
             });
            var result = offeringRepo.GetPackagesByName(packageName);
            OfferingController pc = new OfferingController(mockOffering.Object);
            var a = pc.IpTreatmentPackagesByName(packageName);
            Assert.AreNotEqual(a, result);
        }
        [Test]
        public void SpecialistDetail_InvalidData()
        {
            mockOffering.Setup(x => x.GetSpecialistDetails()).Returns(new List<SpecialistDetail>());
            List<SpecialistDetail> a = mockOffering.Object.GetSpecialistDetails();
            OfferingController pc = new OfferingController(mockOffering.Object);
            var result = pc.Specialists() as ActionResult<SpecialistDetail>;
            var result1 = pc.Specialists();
            Assert.AreNotEqual(result, result1);
        }

    }
}

