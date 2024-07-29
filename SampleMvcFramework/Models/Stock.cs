using SampleMvcFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcFramework.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }

        //public override string ToString()
        //{
        //    return $"<h1>Stock Name: {StockName}</h1><hr/>";
        //}

        public Stock()
        {
            
        }

        public Stock(int id, string name, string desc, double price)
        {
            Id = id;
            Name = name;
            Description = desc;
            UnitPrice = price;
        }

        public static Stock CopyFrom(StockTable row)
        {
            return new Stock(row.Id, row.Name, row.Description, row.UnitPrice);
        }

        public static StockTable CopyTo(Stock stock)
        {
            return new StockTable
            {
                Id = stock.Id,
                Name = stock.Name,
                Description = stock.Description,
                UnitPrice = stock.UnitPrice
            };
        }
    }
}