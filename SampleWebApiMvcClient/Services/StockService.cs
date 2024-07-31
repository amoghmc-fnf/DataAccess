using SampleWebApiMvcClient.Models;
using System.Text;
using System.Text.Json;

namespace SampleWebApiMvcClient.Services
{
    public interface IStockService
    {
        List<Stock> GetAllStocks();
        Stock GetStockById(int id);
        void AddNewStock(Stock stock);
        void UpdateStock(Stock stock);
        void DeleteStock(int id);

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
            List<Stock>? stocks = new List<Stock>();
            var data = httpClient.GetStreamAsync("Stocks").Result;

            if (data != null)
            {
                stocks = JsonSerializer.DeserializeAsync<List<Stock>>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }).Result;
            }
            return stocks;
        }

        public void AddNewStock(Stock stock)
        {
            var json = JsonSerializer.Serialize(stock);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("Stocks", content).Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }

        public void DeleteStock(int id)
        {
            var result = httpClient.DeleteAsync($"Stocks/{id}").Result;
            var deletedRecord = JsonSerializer.Deserialize<Stock>(
                result.Content.ReadAsStringAsync().Result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            if (deletedRecord is null)
            {
                throw new Exception("Stock not found to delete!");
            }
        }

        public Stock GetStockById(int id)
        {
            var stock = new Stock();
            
            using (var response = httpClient.GetStreamAsync($"Stocks/{id}"))
            {
                var data = response.Result;
                stock = JsonSerializer.DeserializeAsync<Stock>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }).Result;
            }
            return stock;
        }

        public void UpdateStock(Stock stock)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(stock);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var result = httpClient.PutAsync("Stocks", content).Result;
                Console.WriteLine(result.Content.ReadAsStringAsync().Result);
            }
            catch (Exception ex)
            {
                throw new Exception("Stock not found to update!", ex);
            }
        }
    }
}
