using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Collections;
using System.Xml.Linq;

namespace WebApplication4.Pages.Employees
{
    public class IndexModel : PageModel
    {
        public List<EmpReg> emps = new List<EmpReg>();
        public string message = "Employee Record Deleted";
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=ARJUN;Initial Catalog=Employees;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM EmpReg;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader()) 
                        {
                            while (reader.Read()) 
                            {
                                int count = emps.Count;
                                EmpReg emp = new EmpReg();
                                emp.EmpID = reader.GetString(0);
                                emp.EmpName = reader.GetString(1);
                                emp.Email = reader.GetString(2);
                                emp.DoB = reader.GetString(5);
                                emp.Phone = reader.GetString(4);
                                emp.Department = reader.GetString(5);

                                emps.Add(emp);
                            }
                        }
                    }
               

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
    public class EmpReg
    {
        public string? EmpID;
        public string? EmpName;
        public string? Email;
        public string? DoB;
        public string? Phone;
        public string? Department;
    }
}
