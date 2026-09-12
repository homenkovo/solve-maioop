class ShopDao : IPrimary {
    public long Id { set; get; }
    public string Name { set; get; }
    public string Code { set; get; }

    private static readonly Random random = new();

    public ShopDao(string name, string code, long id = 0) {
        Name = name;
        Code = code;
        Id = id;
        while (Id == 0) {
            Id = random.NextInt64();
        }
    }

    public ShopDao(long id, string name, string code): this(name, code, id) {}

    public ShopDao(): this("", "") {}
}
