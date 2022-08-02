using System;
namespace BestBuyBestPractices
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments(); //stubbed out method
        public void InsertDepartment(string newDepartmentName); 
    }
}

