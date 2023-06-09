﻿using WebApiDiplom.Models;

namespace WebApiDiplom.Interfaces
{
    public interface IJobTitleRepository
    {
        ICollection<JobTitle> GetJobTitles();
        JobTitle GetJobTitle(int id);
        ICollection<Employee> GetEmployeeByJobTitle(int jobTitleId);
        bool JobTitleExists(int id);
        bool CreateJobTitle(JobTitle jobTitle);
        bool UpgradeJobTitle(JobTitle jobTitle);
        bool DeleteJobTitle(JobTitle jobTitle);
        bool Save();
    }
}
