using Core;

namespace Shop.Bll;

class ClientBlo : IPrimary
{
    public long Id { private set; get; }
    public string FirstName { set; get; }
    public string LastName { set; get; }
    public string Patronymic { set; get; }
    public DateOnly Birthday { set; get; }
    public int Year
    {
        get
        {
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);

            return Birthday.Year - date.Year - (date.Month < Birthday.Month || (date.Month == Birthday.Month && date.Day < Birthday.Day) ? 1 : 0);
        }
    }

    private static readonly Random random = new();

    public ClientBlo(string firstname, string lastname, string patronymic = "", DateOnly? birthday = null, long id = 0)
    {
        FirstName = firstname;
        LastName = lastname;
        Patronymic = patronymic;
        Birthday = birthday ?? new DateOnly(1900, 1, 1);
        Id = id;
        while (Id == 0)
        {
            Id = random.NextInt64();
        }
    }

    public ClientBlo(long id, string firstname, string lastname, string patronymic, DateOnly birthday) : this(firstname, lastname, patronymic, birthday, id) { }
}
