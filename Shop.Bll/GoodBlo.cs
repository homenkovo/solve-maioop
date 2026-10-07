using Core;

namespace Shop.Dal;

public class GoodBlo : IPrimary
{
    public long Id { set; get; }

    private string _name = "";
    private string _code = "";

    public string Name
    {
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            _name = value;
        }
        get => _name;
    }

    public string Code
    {
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Code cannot be empty.");
            }

            _code = value;
        }
        get => _code;
    }

    public decimal Cost { set; get; }

    private static readonly Random random = new();
    public GoodBlo(string name, string code, decimal cost, long id = 0)
    {
        Name = name;
        Code = code;
        Cost = cost;
        Id = id;
        while (Id == 0)
        {
            Id = random.NextInt64();
        }
    }

    public GoodBlo(long id, string name, string code, decimal cost) : this(name, code, cost, id) { }
}

