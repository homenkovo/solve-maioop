using Core;

namespace Shop.Dal;

public class ClientDao : IPrimary
{
    public long Id { set; get; }
    public string FirstName { set; get; } = "";
    public string LastName { set; get; } = "";
    public string Patronymic { set; get; } = "";
    public DateOnly Birthday { set; get; }
}
