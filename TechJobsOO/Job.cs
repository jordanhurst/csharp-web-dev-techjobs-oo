using System;
namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.
        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employer, Location location, PositionType position, CoreCompetency core):this()
        {
            Name = name;
            EmployerName = employer;
            EmployerLocation = location;
            JobType = position;
            JobCoreCompetency = core;
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(Name) &&
                EmployerName == null &&
                EmployerLocation == null &&
                JobType == null &&
                JobCoreCompetency == null)
            {
                return "OOPS! This job does not seem to exist.";
            }
            if (String.IsNullOrEmpty(Name))
            {
                Name = "Data not available";
            }
            if (String.IsNullOrEmpty(EmployerName.Value))
            {
                EmployerName.Value = "Data not available";
            }
            if (String.IsNullOrEmpty(EmployerLocation.Value))
            {
                EmployerLocation.Value = "Data not available";
            }
            if (String.IsNullOrEmpty(JobType.Value))
            {
                JobType.Value = "Data not available";
            }
            if (String.IsNullOrEmpty(JobCoreCompetency.Value))
            {
                JobCoreCompetency.Value = "Data not available";
            }
            String str = "\n" +
                "ID: " + Id + "\n" +
                "Name: " + Name + "\n" +
                "Employer: " + EmployerName.Value + "\n" +
                "Location: " + EmployerLocation.Value + "\n" +
                "Position Type: " + JobType.Value + "\n" +
                "Core Competency: " + JobCoreCompetency.Value + "\n";
            return str;
        }

    }
}
