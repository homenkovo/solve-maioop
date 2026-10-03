using Core;

namespace Shop.Dal;

public class GoodDao : IPrimary
{
    public long Id { set; get; }
    public string Name { set; get; } = "";
    public string Code { set; get; } = "";
    public decimal Cost { set; get; }
}

