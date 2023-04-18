using WebApiDiplom.Data;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Repository
{
    public class JobTitleRepository : IJobTitleRepository
    {
        private readonly DataContext _context;

        public JobTitleRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateJobTitle(JobTitle jobTitle)
        {
            _context.Add(jobTitle);
            return Save();
        }

        public ICollection<Employee> GetEmployeeByJobTitle(int jobTitleId)
        {
            return _context.Employees.Where(e => e.JobTitle.Id == jobTitleId).ToList();
        }

        public JobTitle GetJobTitle(int id)
        {
            return _context.JobTitles.Where(j => j.Id == id).FirstOrDefault();
        }

        public ICollection<JobTitle> GetJobTitles()
        {
            return _context.JobTitles.OrderBy(j => j.Id).ToList();
        }

        public bool JobTitleExists(int id)
        {
            return _context.JobTitles.Any(j => j.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpgradeJobTitle(JobTitle jobTitle)
        {
            _context.Update(jobTitle);
            return Save();
        }
    }
}
