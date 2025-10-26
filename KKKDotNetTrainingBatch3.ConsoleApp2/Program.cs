
using KKKDotNetTrainingBatch3.ConsoleApp2;


//Console.WriteLine("ADO.Net CRUD");
//ProductADONetService ps = new ProductADONetService();
//ps.Read();
//ps.Create();
//ps.Update();
//ps.Delete();


//Console.WriteLine("Dapper CRUD");
ProductDapperService pds = new ProductDapperService();
//pds.Read();
//pds.Create();
//pds.Update();
//pds.Delete();

ProductEFCoreService pefCore = new ProductEFCoreService();
pefCore.Read();
