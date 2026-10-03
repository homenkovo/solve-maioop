using Core;

namespace Shop.Bll;

public class ShopBlo : IPrimary
{
    public long Id { private set; get; }

    private string _name = "";
    private string _code = "";

    public string Name { set {
        if (string.IsNullOrWhiteSpace(value)) {
            throw new ArgumentException("Name cannot be empty.");
        }

        _name = value;
    } get => _name; }

    public string Code { set {
        if (string.IsNullOrWhiteSpace(value)) {
            throw new ArgumentException("Code cannot be empty.");
        }

        _code = value;
    } get => _code; }

    private static readonly Random random = new();

    public ShopBlo(string name, string code, long id = 0)
    {
        Name = name;
        Code = code;
        Id = id;
        while (Id == 0)
        {
            Id = random.NextInt64();
        }
    }

    public ShopBlo(long id, string name, string code) : this(name, code, id) { }
}
