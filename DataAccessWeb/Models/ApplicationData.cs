using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DataAccessWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }

    public static class ApplicationData
    {
        public static HashSet<Product> CreateProducts(string dirName)
        {
            HashSet<Product> products = new HashSet<Product>();
            var files = Directory.GetFiles(dirName);
            int i = 1;
            var ran = new Random();
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var fileName = fileInfo.Name.Split('.')[0];
                var product = new Product();
                product.Name = fileName;
                product.Id = i++;
                product.Price = ran.Next(100, 250);
                product.Image = $"\\Images\\{fileInfo.Name}";
                products.Add(product);
            }
            return products;
        }
    }
}