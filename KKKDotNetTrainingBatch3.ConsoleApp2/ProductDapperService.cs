using Dapper;
using KKKDotNetTrainingBatch3.ConsoleApp2.Helper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Dapper's CRUD
namespace KKKDotNetTrainingBatch3.ConsoleApp2
{
    public class ProductDapperService
    {
        public void Read()
        {
            using (IDbConnection db = new SqlConnection(dbHelper.GetConnection().ConnectionString))
            {
                db.Open();
                string query = dbHelper.selectQuery("Tbl_Product");

                List<ProductDto> lst = db.Query<ProductDto>(query).ToList();
                for (int i = 0; i < lst.Count; i++)
                {                                       
                    string id = lst[i].ProductID.ToString();
                    string productName = lst[i].ProductName.ToString();
                    double price = Convert.ToDouble(lst[i].Price);
                    string Qty = lst[i].Quantity.ToString();
                    string str = $"{id}. ProductName: {productName}, Price: ${price.ToString("0.00")}, Qty: {Qty}";
                    Console.WriteLine(str);
                }
            }
        }

        public void Create()
        {
            using (IDbConnection db = new SqlConnection(dbHelper.GetConnection().ConnectionString))
            {
                db.Open();
                string query = dbHelper.insertQuery();

                int result = db.Execute(query);
                string message = result > 0 ? "Create Successful." : "Create Failed.";
                Console.WriteLine(message);
            }
        }

        public void Update()
        {
            using (IDbConnection db = new SqlConnection(dbHelper.GetConnection().ConnectionString))
            {
                db.Open();
                string query = dbHelper.updateQuery();
                int result = db.Execute(query);
                string message = result > 0 ? "Update Successful." : "Update Failed.";
                Console.WriteLine(message);
            }
        }

        public void Delete()
        {
            using (IDbConnection db = new SqlConnection(dbHelper.GetConnection().ConnectionString))
            {
                db.Open();
                string query = dbHelper.deleteQuery();

                int result = db.Execute(query);
                string message = result > 0 ? "Delete Successful." : "Delete Failed.";
                Console.WriteLine(message);

            }
        }
    }

}

    public class ProductDto // DTO = Data Transfer Object
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public int DeleteFlag { get; set; }
    }

