namespace SampleWebApiMvcClient.Models
{
    public class Stock
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public double price { get; set; }
    }
}
