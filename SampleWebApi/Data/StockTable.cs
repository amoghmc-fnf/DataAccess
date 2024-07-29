using System;
using System.Collections.Generic;

namespace SampleWebApi.Data;

public partial class StockTable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double UnitPrice { get; set; }
}
