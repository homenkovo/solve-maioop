using Core;

namespace Shop.Dal;

public class ShopDao : IPrimary
{
    public long Id { set; get; }
    public string Name { set; get; } = "";
    public string Code { set; get; } = "";
}
