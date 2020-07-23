using System;
using System.Collections.Generic;

namespace DapperIntero
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments(); //Stubbed out method
    }
}
