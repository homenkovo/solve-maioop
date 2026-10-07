using Core;

namespace Shop.Dal;

public class GoodDao : IPrimary
{
    public long Id { set; get; }
    public string Name { set; get; } = "";
    public string Code { set; get; } = "";
    public decimal Cost { set; get; }

    public GoodDao(long id, string name, string code, decimal cost)
    {
        Id = id;
        Name = name;
        Code = code;
        Cost = cost;
    }

    public GoodDao() { }
}

