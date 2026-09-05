class Person
{
    public long Id { private set; get; }
    public string Name { set; get; }
    public string Surname { set; get; }
    public int Year { private set; get; }
    public int Rating { set; get; }

    private static readonly Random random = new();

    public Person() {
        Name = "";
        Surname = "";
    }

    public Person(string name, string surname, int year, int rating = 0) {
        Name = name;
        Surname = surname;
        Year = year;
        Rating = rating;
    }

    public Person(long id, string name, string surname, int year, int rating = 0): this(name, surname, year, rating)
    {
        Id = id;
    }
}
