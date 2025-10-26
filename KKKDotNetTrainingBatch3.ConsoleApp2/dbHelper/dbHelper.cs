using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKKDotNetTrainingBatch3.ConsoleApp2.Helper
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
   
        public static class dbHelper
        {
            public static SqlConnection GetConnection()
            {
                SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
                sqlConnectionStringBuilder.DataSource = ".";  //server name
                sqlConnectionStringBuilder.InitialCatalog = "Batch3MiniPOS";  //database name
                sqlConnectionStringBuilder.UserID = "sa";
                sqlConnectionStringBuilder.Password = "sasa@123";
                sqlConnectionStringBuilder.TrustServerCertificate = true;
                SqlConnection conn = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
                return conn;
            }

            public static string selectQuery(string tblName)
            {
                string str = "";

                if (tblName == "Tbl_Product")
                {
                    str = @"SELECT [ProductID]
                                  ,[ProductName]
                                  ,[Quantity]
                                  ,[Price]
                                  ,[DeleteFlag]     
                              FROM [dbo].[Tbl_Product]";
                 }
                 else
                {

                 }
                return str;
            }

            public static string insertQuery()
            {
                string query = @"INSERT INTO [dbo].[Tbl_Product]
                                       ([ProductName]
                                       ,[Quantity]
                                       ,[Price]
                                       ,[DeleteFlag]
                                       ,[CreatedDateTime])
                                    VALUES
                                       ('Test'
                                       ,10
                                       ,10000
                                       ,0
                                        ,GETDATE())";
                return query;
            }

            public static string updateQuery()
            {
                string query = @"UPDATE [dbo].[Tbl_Product]
                                   SET [ProductName] = 'Test2'
                                      ,[Quantity] = 20
                                      ,[Price] = 2000
                                      ,[ModifiedDateTime] = GETDATE() 
                                    WHERE ProductID = 5";
                return query;
            }


            public static string deleteQuery() {
                string query = @"Delete [dbo].[Tbl_Product]
                                    WHERE ProductID = 5";
                return query;
            }
               
        }
 }
