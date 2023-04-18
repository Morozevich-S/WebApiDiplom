using WebApiDiplom.Models;

namespace WebApiDiplom.Interfaces
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        Employee GetEmployee(int id);
        Employee GetEmployeeByRentalContract(int contractId);
        ICollection<RentalContract> GetRentalContractByEmployee(int employeeId);
        bool EmployeeExists(int id);
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool Save();
    }
}
