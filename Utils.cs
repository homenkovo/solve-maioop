using System.Text.Json;

class Utils
{
    private static Random random = new();
    public static void WritePerson(string filename, Person person)
    {
        File.WriteAllText(filename, JsonSerializer.Serialize(person));
    }
    public static void WritePersonBinary(string filename, Person person)
    {
        using FileStream fileStream = File.Open(filename, FileMode.Create);
        using BinaryWriter writer = new(fileStream);
        writer.Write(person.Id);
        writer.Write(person.Name);
        writer.Write(person.Surname);
        writer.Write(person.Year);
        writer.Write(person.Rating);
    }
    public static Person ReadPerson(string filename)
    {
        return JsonSerializer.Deserialize<Person>(File.ReadAllText(filename))!;
    }
    public static Person ReadPersonBinary(string filename)
    {
        using FileStream fileStream = File.Open(filename, FileMode.Open);
        using BinaryReader reader = new(fileStream);
        long id = reader.ReadInt64();
        String name = reader.ReadString();
        String surname = reader.ReadString();
        int year = reader.ReadInt32();
        int rating = reader.ReadInt32();

        return new Person(name, surname, year, rating, id);
    }
    public static Person[] GenerateNPersons(int n)
    {
        Person[] persons = new Person[n];
        for (int i = 0; i < n; ++i)
        {
            
        }
        return persons;
    }
        public static Client[] InitClients(int length = 20) {
        Client[] clients = new Client[length];
        for (int i = 0; i < clients.Length; ++i) {
            clients[i] = new Client($"Name #{random.Next()}", $"Surname #{random.Next()}", new DateOnly(random.Next(1, 2025), random.Next(1, 13), random.Next(1, 29)));
        }

        return clients;
    }
    public static void WriteClients(string filename, Client[] clients) {
        File.WriteAllText(filename, JsonSerializer.Serialize(clients));
    }
    public static Client[]? ReadClients(string filename) {
        return JsonSerializer.Deserialize<Client[]>(File.ReadAllText(filename));
    }
    public static void PrintClients(Client[] clients) {
        Console.WriteLine(JsonSerializer.Serialize(clients));
    }
    public static Good[] InitGoods(int length = 20) {
        Good[] goods = new Good[length];
        
        for (int i = 0; i < goods.Length; ++i) {
            goods[i] = new Good($"Name #{random.Next()}", $"Code #{random.Next()}", random.Next());
        }
        return goods;
    }
    public static void WriteGoods(string filename, Good[] goods) {
        File.WriteAllText(filename, JsonSerializer.Serialize(goods));
    }
    public static Good[]? ReadGoods(string filename) {
        return JsonSerializer.Deserialize<Good[]>(File.ReadAllText(filename));
    }
    public static void PrintGoods(Good[] goods) {
        Console.WriteLine(JsonSerializer.Serialize(goods));
    }
    public static Shop[] InitShops(int length = 20) {
        Shop[] shops = new Shop[length];
        for (int i = 0; i < shops.Length; ++i) {
            shops[i] = new Shop($"Name #{random.Next()}", $"CODE{random.Next(1000, 10000)}");
        }

        return shops;
    }
    public static void WriteShops(string filename, Shop[] shops) {
        File.WriteAllText(filename, JsonSerializer.Serialize(shops));
    }
    public static Shop[]? ReadShops(string filename) {
        return JsonSerializer.Deserialize<Shop[]>(File.ReadAllText(filename));
    }
    public static void PrintShops(Shop[] shops) {
        Console.WriteLine(JsonSerializer.Serialize(shops));
    }
}
