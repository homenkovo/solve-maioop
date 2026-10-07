using Core;

namespace Shop.Dal;

public class ClientDao : IPrimary
{
    public long Id { set; get; }
    public string FirstName { set; get; } = "";
    public string LastName { set; get; } = "";
    public string Patronymic { set; get; } = "";
    public DateOnly Birthday { set; get; }

    public ClientDao(long id, string firstName, string lastName, string patronymic, DateOnly birthday)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        patronymic = Patronymic;
        Birthday = birthday;
    }

    public ClientDao() { }
}
