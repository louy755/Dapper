using System;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DapperIntero
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("application.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            //Insert to database new department!
            var repo1 = new DapperDepartmentRepository(conn);
            // ask user
            Console.WriteLine("Type a new Department Name: ");
            // Assign new 
            var newDep = Console.ReadLine();

            repo1.InsertDepartment(newDep);


            // delete 
            //var repo1 = new DapperDepartmentRepository(conn);
            //repo1.DeletDepartment("Code");

            var repo = new DapperDepartmentRepository(conn);
            var departments = repo.GetAllDepartments();


            foreach (var dep in departments)
            {
                Console.WriteLine($"{dep.DepartmentID} {dep.Name}");
            }

            
        }
    }
}
