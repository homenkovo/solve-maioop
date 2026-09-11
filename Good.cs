class Good : IPrimary {
    public long Id { private set; get; }
    public string Name { set; get; }
    public string Code { set; get; }
    public decimal Cost { set; get; }

    private static readonly Random random = new();
    public Good(string name, string code, decimal cost, long id = 0) {
        Name = name;
        Code = code;
        Cost = cost;
        Id = id;
        while (Id == 0) {
            Id = random.NextInt64();
        }
    }

    public Good(long id, string name, string code, decimal cost): this(name, code, cost, id) {}

    public Good(): this("", "", 0) {}
}
