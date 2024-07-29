using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebApi.Data;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockMarketController : ControllerBase
    {
        private readonly FnfTrainingContext _context;

        public StockMarketController(FnfTrainingContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Stocks")]
        public List<StockTable> AllStocks()
        {
            var result = _context.StockTables.ToList();
            return result;
        }

        [HttpGet]
        [Route("Stocks/{id}")]
        public StockTable GetStock(int id)
        {
            var found = _context.StockTables.FirstOrDefault(t => t.Id == id);
            if (found is null)
                throw new NullReferenceException("Stock not found!");
            return found;
        }

        [HttpPost]
        [Route("Stocks")]
        public ObjectResult AddStock(StockTable stock)
        {
            _context.StockTables.Add(stock);
            _context.SaveChanges();
            return Ok("Added successfully!");
        }
    }
}
