using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Windows.Input;
using WebApplication4.Pages.Employees;

namespace WebApplication4.Pages
{
    public class PrivacyModel : PageModel
    {
        public EmpReg emps = new EmpReg();

        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            emps.EmpID = Request.Form["EmpID"];
            emps.EmpName = Request.Form["EmpName"];
            emps.Email = Request.Form["Email"];
            emps.DoB = Request.Form["DoB"];
            emps.Phone = Request.Form["Phone"];
            emps.Department = Request.Form["Department"];

            try
            {
                
                String connectionString = "Data Source=ARJUN;Initial Catalog=Employees;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO EmpReg (EmpID,EmpName,Email,DoB,Phone,Department) VALUES (@EmpID, @EmpName, @Email, @DoB, @Phone, @Department);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@EmpID", emps.EmpID);
                        command.Parameters.AddWithValue("@EmpName",emps.EmpName);
                        command.Parameters.AddWithValue("@Email", emps.Email);
                        command.Parameters.AddWithValue("@DoB", emps.DoB);
                        command.Parameters.AddWithValue("@Phone", emps.Phone);
                        command.Parameters.AddWithValue("@Department", emps.Department);

                        command.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

}
