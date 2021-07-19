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
namespace TreatmentOfferingTesting
{
    public class OfferingValidTests
    {
        PackageDetail package = new PackageDetail();
        List<PackageDetail> packageDetails;
        SpecialistDetail specialistDetail = new SpecialistDetail();
        List<SpecialistDetail> specialists;
        Mock<IOfferingRepo> mockOffering;
        OfferingRepo offeringRepo;
        [SetUp]
        public void Setup()
        {
            var option = new DbContextOptionsBuilder<TreatmentOfferingDbContext>().UseInMemoryDatabase(databaseName: "TreatmentOffering").Options;
            var context = new TreatmentOfferingDbContext(option);
            mockOffering = new Mock<IOfferingRepo>();
            offeringRepo = new OfferingRepo(context);
            packageDetails = new List<PackageDetail>()
           {
               new PackageDetail { PackageId = 1, Ailment = "Orthopaedics", TreatmentPackageName = "Package 1", TestDetails = "OPT1, OPT2", Cost = 2500, TreatmentDuration = 4 },
               new PackageDetail { PackageId = 2, Ailment = "Orthopaedics", TreatmentPackageName = "Package 2", TestDetails = "OPT3,OPT4", Cost = 3000, TreatmentDuration = 6 },
               new PackageDetail { PackageId = 3, Ailment ="Urology", TreatmentPackageName = "Package 1", TestDetails = "UPT1,UPT2", Cost = 4000, TreatmentDuration = 4 },
               new PackageDetail { PackageId = 4, Ailment = "Urology", TreatmentPackageName = "Package 2", TestDetails = "UPT3,UPT4", Cost = 5000, TreatmentDuration =6 }
           };
            specialists = new List<SpecialistDetail>()
           {

                new SpecialistDetail { Id = 1, Name = "Shriny", ExperienceInYears = 4, ContactNumber = 8514235879, AreaOfExpertise = "Orthopaedics" },
                new SpecialistDetail { Id = 2, Name = "Joey", ExperienceInYears = 13, ContactNumber = 9875214000, AreaOfExpertise = "Orthopaedics" },
                new SpecialistDetail { Id = 3, Name = "Chandler", ExperienceInYears = 2, ContactNumber = 9965231470, AreaOfExpertise = "Urology" },
                new SpecialistDetail { Id = 4, Name = "Rachel", ExperienceInYears = 15, ContactNumber = 6358290001, AreaOfExpertise = "Urology" }

            };
        }

        [Test]
        public void GetTreatmentPackages_ValidData()
        {
            mockOffering.Setup(x => x.GetTreatmentPackages()).Returns(packageDetails);
            var result = offeringRepo.GetTreatmentPackages();
            Assert.NotNull(result);

        }
        [TestCase("Package 1")]
        [TestCase("Package 2")]
        public void GetPackagesByName_ValidData(string packageName)
        {
            mockOffering.Setup(x => x.GetPackagesByName(packageName)).Returns(packageDetails);
            var result = offeringRepo.GetPackagesByName(packageName);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetSpecialistDetails_ValidData()
        {
            mockOffering.Setup(x => x.GetSpecialistDetails()).Returns(specialists);
            var result = offeringRepo.GetSpecialistDetails();
            Assert.IsNotNull(result);
        }
        [Test]
        public void IpTreatmentPackages_ValidData()
        {
            mockOffering.Setup(x => x.GetTreatmentPackages()).Returns(packageDetails);
            OfferingController pc = new OfferingController(mockOffering.Object);
            var result = pc.IpTreatmentPackages();
            Assert.IsNotNull(result);

        }
        [TestCase("Package 1")]
        [TestCase("Package 2")]
        public void PackagesByName_ValidData(string packageName)
        {
            mockOffering.Setup(x => x.GetPackagesByName(packageName)).Returns(packageDetails);
            OfferingController pc = new OfferingController(mockOffering.Object);
            var result = pc.IpTreatmentPackagesByName(packageName);
            Assert.IsNotNull(result);
        }
        [Test]
        public void SpecialistDetail_ValidData()
        {
            mockOffering.Setup(x => x.GetSpecialistDetails()).Returns(specialists);
            OfferingController pc = new OfferingController(mockOffering.Object);
            var result = pc.Specialists();
            Assert.IsNotNull(result);
        }

    }
}