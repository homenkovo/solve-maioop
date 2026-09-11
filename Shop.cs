class Shop : IPrimary {
    public long Id { private set; get; }
    public string Name { set; get; }
    public string Code { set; get; }

    private static readonly Random random = new();

    public Shop(string name, string code, long id = 0) {
        Name = name;
        Code = code;
        Id = id;
        while (Id == 0) {
            Id = random.NextInt64();
        }
    }

    public Shop(long id, string name, string code): this(name, code, id) {}

    public Shop(): this("", "") {}
}
