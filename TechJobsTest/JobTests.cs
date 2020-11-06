using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTest
{
    [TestClass]
    public class JobsTests
    {
        [TestMethod]
        public void TestSettingJobId()
        {
            Job newJob1 = new Job();
            Job newJob2 = new Job();
            Assert.AreNotEqual(newJob1.Id, newJob2.Id);
            Assert.AreEqual(newJob2.Id - newJob1.Id, 1);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job testJob = new Job("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality Control"), new CoreCompetency("Persistence"));

            Assert.AreEqual(testJob.Name, "Product Tester");
            Assert.AreEqual(testJob.EmployerName.Value, "ACME");
            Assert.AreEqual(testJob.EmployerLocation.Value, "Desert");
            Assert.AreEqual(testJob.JobType.Value, "Quality Control");
            Assert.AreEqual(testJob.JobCoreCompetency.Value, "Persistence");
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job testJob1 = new Job("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality Control"), new CoreCompetency("Persistence"));
            Job testJob2 = new Job("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality Control"), new CoreCompetency("Persistence"));

            Assert.IsFalse(testJob1.Equals(testJob2));
        }

        [TestMethod]
        public void ToStringMethodStartsEndsWithBlankLine()
        {
            Job testJob = new Job("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality Control"), new CoreCompetency("Persistence"));

            StringAssert.StartsWith(testJob.ToString(), "\n");
            StringAssert.EndsWith(testJob.ToString(), "\n");
        }

        [TestMethod]
        public void ToStringPassesCorrectValues()
        {
            Job testJob = new Job("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality Control"), new CoreCompetency("Persistence"));

            StringAssert.Contains(testJob.ToString(), "ID: " + testJob.Id);
            StringAssert.Contains(testJob.ToString(), "Name: Product Tester");
            StringAssert.Contains(testJob.ToString(), "Employer: ACME");
            StringAssert.Contains(testJob.ToString(), "Location: Desert");
            StringAssert.Contains(testJob.ToString(), "Position Type: Quality Control");
            StringAssert.Contains(testJob.ToString(), "Core Competency: Persistence");
        }

        [TestMethod]
        public void ToStringProperlyUtilizesEmptyFields()
        {
            Job testJob = new Job("some job", new Employer(), new Location(), new PositionType(), new CoreCompetency());

            StringAssert.Contains(testJob.ToString(), "ID: " + testJob.Id);
            StringAssert.Contains(testJob.ToString(), "Name: some job");
            StringAssert.Contains(testJob.ToString(), "Employer: Data not available");
            StringAssert.Contains(testJob.ToString(), "Location: Data not available");
            StringAssert.Contains(testJob.ToString(), "Position Type: Data not available");
            StringAssert.Contains(testJob.ToString(), "Core Competency: Data not available");
        }

        [TestMethod]
        public void ToStringUtilizesAllFieldsEmpty()
        {
            Job testJob = new Job();

            StringAssert.Contains(testJob.ToString(), "OOPS! This job does not seem to exist.");
        }
    }
}
