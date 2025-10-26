using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// ADO.Net CRUD
namespace KKKDotNetTrainingBatch3.ConsoleApp2
{
    using KKKDotNetTrainingBatch3.ConsoleApp2.Helper;
    using Microsoft.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

        
        public class ProductADONetService
        {
       
        public void Read()
            {
                SqlConnection conn = new SqlConnection(dbHelper.GetConnection().ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(dbHelper.selectQuery("Tbl_Product"), conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);   // execute the query and fill the data table

                conn.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];                   
                    int rowNo = i + 1;
                    decimal price = Convert.ToDecimal(row["Price"]);                   
                    Console.WriteLine(rowNo.ToString() + ". " + row["ProductName"] + "($" + price.ToString("0.00") + ")");                                    
                }
            }

            public void Create()
            {    
                SqlConnection conn = new SqlConnection(dbHelper.GetConnection().ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(dbHelper.insertQuery(), conn);
                int result = cmd.ExecuteNonQuery();

                conn.Close();
                string msg = result > 0 ? "Save Successful." : "Save Failed.";

                Console.WriteLine(msg);
            }

            public void Update()
            {   
                SqlConnection conn = new SqlConnection(dbHelper.GetConnection().ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(dbHelper.updateQuery(), conn);
                int result = cmd.ExecuteNonQuery();

                conn.Close();
                string msg = result > 0 ? "Update Successful." : "Update Failed.";

                Console.WriteLine(msg);
            }

            public void Delete()
            {               
                SqlConnection conn = new SqlConnection(dbHelper.GetConnection().ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(dbHelper.deleteQuery(), conn);
                int result = cmd.ExecuteNonQuery();

                conn.Close();
                string msg = result > 0 ? "Delete Successful." : "Delete Failed.";

                Console.WriteLine(msg);
            }
        }   
}
