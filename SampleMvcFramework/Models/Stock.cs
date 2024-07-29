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
    }
}