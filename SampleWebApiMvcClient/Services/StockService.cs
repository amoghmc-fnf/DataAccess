using SampleWebApiMvcClient.Models;
using System.Text.Json;

namespace SampleWebApiMvcClient.Services
{
    public interface IStockService
    {
        List<Stock> GetAllStocks();
        Stock GetStockById(int id);
        void AddNewStock(Stock stock);
        void UpdateStock(Stock stock);
        void DeleteStock(Stock stock);

    }
    public class StockService : IStockService
    {
        private readonly HttpClient httpClient;
        public StockService(HttpClient client)
        {
            httpClient = client;
        }
        public List<Stock> GetAllStocks()
        {
            List<Stock> stocks = new List<Stock>();
            var response = httpClient.GetAsync("Stocks");
            var data = response.Result.Content.ReadAsStringAsync().Result;

            if (data != "")
            {
                stocks = JsonSerializer.Deserialize<List<Stock>>(data);
            }
            return stocks;
        }

        public void AddNewStock(Stock stock)
        {
        }

        public void DeleteStock(Stock stock)
        {
            throw new NotImplementedException();
        }

        public Stock GetStockById(int id)
        {
            var stock = new Stock();
            
            using (var response = httpClient.GetAsync($"Stocks/{id}"))
            {
                var data = response.Result.Content?.ReadAsStringAsync().Result;
                stock = JsonSerializer.Deserialize<Stock>(data);
            }
            return stock;
        }

        public void UpdateStock(Stock stock)
        {
            throw new NotImplementedException();
        }
    }
}
