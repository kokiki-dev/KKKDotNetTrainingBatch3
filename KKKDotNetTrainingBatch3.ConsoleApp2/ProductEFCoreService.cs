using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKKDotNetTrainingBatch3.ConsoleApp2
{
    public class ProductEFCoreService
    {
        private readonly AppDbContext _db;

        public ProductEFCoreService()
        {
            _db = new AppDbContext();
        }

        public void Read()
        {
            //AppDbContext db = new AppDbContext();
            var lst = _db.Products.Where(x => x.DeleteFlag == false).ToList();
            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine(lst[i].ProductName);
                Console.WriteLine(lst[i].ProductId);
            }
        }

        public void Create()
        {
            var item = new Tbl_Product()
            {
                ProductName = "Test product",
                Price = 10000,
                Quantity = 5,
                CreatedDateTime = DateTime.Now,
                DeleteFlag = false,
            };
            _db.Products.Add(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Creating Successful." : "Creating Failed.";
            Console.WriteLine(message);
        }

        public void Update()
        {
            // linq
            //var item = _db.Products.Where(x => x.ProductId == 9).FirstOrDefault(); // null?
            var item = _db.Products.FirstOrDefault(x => x.ProductId == 9); // null?
            if (item is null)
            {
                return;
            }

            item.ProductName = "apple";
            item.ModifiedDateTime = DateTime.Now;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            var item = _db.Products.FirstOrDefault(x => x.ProductId == 9); // null?
            if (item is null)
            {
                return;
            }
            _db.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }
    }
}
