using SampleMvcFramework.Data;
using SampleMvcFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcFramework.Services
{
    public interface IStockService
    {
        List<Stock> GetAllStocks();
        Stock GetStock(int id);
        void DeleteStock(int id);
        void UpdateStock(Stock stock);
        void AddStock(Stock stock);

    }
    public class StockService : IStockService
    {
        private readonly FnfTrainingEntities _trainingEntities;
        public StockService()
        {
            _trainingEntities = new FnfTrainingEntities();
        }
        public void AddStock(Stock stock)
        {
            StockTable row = new StockTable 
            {
                Name = stock.Name,
                Description = stock.Description,
                UnitPrice = stock.UnitPrice
            };

            _trainingEntities.StockTables.Add(row);
            _trainingEntities.SaveChanges();

        }

        public void DeleteStock(int id)
        {
            var found = _trainingEntities.StockTables.FirstOrDefault(s => s.Id == id);
            if (found is null)
                throw new NullReferenceException("Stock not found to delete!");

            _trainingEntities.StockTables.Remove(found);
            _trainingEntities.SaveChanges();
        }


        public List<Stock> GetAllStocks()
        {
            var stocks = new List<Stock>();
            foreach (var stock in _trainingEntities.StockTables)
            {
                stocks.Add(Stock.CopyFrom(stock));
            }
            return stocks;
        }

        public Stock GetStock(int id)
        {
            var found = _trainingEntities.StockTables.FirstOrDefault(s => s.Id == id);
            if (found is null)
                throw new NullReferenceException("Stock not found!");

            return Stock.CopyFrom(found);
        }

        public void UpdateStock(Stock stock)
        {
            var found = _trainingEntities.StockTables.FirstOrDefault(s => s.Id == stock.Id);
            if (found is null)
                throw new NullReferenceException("Stock not found to update!");

            found.Name = stock.Name;
            found.Description = stock.Description;
            found.UnitPrice = stock.UnitPrice;
            _trainingEntities.SaveChanges();
        }
    }
}