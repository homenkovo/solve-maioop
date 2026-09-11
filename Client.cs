class Client : IPrimary {
    public long Id { private set; get; }
    public string Name { set; get; }
    public string Surname { set; get; }
    public string Other { set; get; }
    public DateOnly Birth { set; get; }
    public int Year { get {
        DateOnly date = DateOnly.FromDateTime(DateTime.Now);

        return Birth.Year - date.Year - (date.Month < Birth.Month || (date.Month == Birth.Month && date.Day < Birth.Day) ? 1 : 0);
    } }

    private static readonly Random random = new();

    public Client(string name, string surname, DateOnly birth, string other = "", long id = 0) {
        Name = name;
        Surname = surname;
        Birth = birth;
        Other = other;
        Id = id;
        while (Id == 0) {
            Id = random.NextInt64();
        }
    }

    public Client(long id, string name, string surname, string other, DateOnly birth): this(name, surname, birth, other, id) {}

    public Client(): this("", "", new DateOnly(1, 1, 1)) {}
}
