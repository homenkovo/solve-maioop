using System.Text.Json;
using System.Diagnostics;

class Utils
{
    private static readonly Random random = new Random();
    public static void WritePerson(StreamWriter writer, Person person)
    {
        writer.Write(JsonSerializer.Serialize(person));
    }
    public static void WritePersons(StreamWriter writer, Person[] persons)
    {
        writer.Write(JsonSerializer.Serialize(persons));
    }
    public static void WritePersonBinary(BinaryWriter writer, Person person)
    {
        writer.Write(person.Id);
        writer.Write(person.Name);
        writer.Write(person.Surname);
        writer.Write(person.Year);
        writer.Write(person.Rating);
    }
    public static void WritePersonsBinary(BinaryWriter writer, Person[] persons)
    {
        writer.Write(persons.Length);
        foreach (Person person in persons)
        {
            WritePersonBinary(writer, person);
        }
    }
    public static Person ReadPerson(StreamReader reader)
    {
        return JsonSerializer.Deserialize<Person>(reader.ReadToEnd())!;
    }
    public static Person[] ReadPersons(StreamReader reader)
    {
        return JsonSerializer.Deserialize<Person[]>(reader.ReadToEnd())!;
    }
    public static Person ReadPersonBinary(BinaryReader reader)
    {
        long id = reader.ReadInt64();
        String name = reader.ReadString();
        String surname = reader.ReadString();
        int year = reader.ReadInt32();
        int rating = reader.ReadInt32();

        return new Person(id, name, surname, year, rating);
    }
    public static Person[] ReadPersonsBinary(BinaryReader reader) {
        int n = reader.ReadInt32();
        Person[] persons = new Person[n];
        for (int i = 0; i < n; ++i) {
            persons[i] = ReadPersonBinary(reader);
        }
        return persons;
    }
    public static Person[] GenerateNPersons(int n)
    {
        Person[] persons = new Person[n];
        for (int i = 0; i < n; ++i)
        {
            persons[i] = new Person($"Name #{i}", $"Surname #{i}", random.Next(1900, 2000), random.Next(-100, 100));
        }
        return persons;
    }
    public static void TestPerson(string output, int[] lengths) {
        Directory.CreateDirectory("tmp");
        Stopwatch stopwatch = new Stopwatch();
        using StreamWriter resultWriter = File.CreateText(output);
        resultWriter.WriteLine("Size,Read Time,Binary Read Time");
        foreach (int i in lengths) {
            resultWriter.Write($"{i},");
            Person[] persons = GenerateNPersons(i);
            using (StreamWriter writer = new("tmp/persons")) {
                WritePersons(writer, persons);
            }

            stopwatch.Reset();
            stopwatch.Start();
            using (StreamReader reader = new("tmp/persons")) {
                ReadPersons(reader);
            }
            stopwatch.Stop();

            resultWriter.Write($"{stopwatch.ElapsedTicks},");

            using (FileStream stream = File.Open("tmp/persons", FileMode.OpenOrCreate)) {
                using (BinaryWriter writer = new(stream)) {
                    WritePersonsBinary(writer, persons);
                }
            }

            stopwatch.Reset();
            stopwatch.Start();
            using (FileStream stream = File.Open("tmp/persons", FileMode.Open)) {
                using (BinaryReader reader = new(stream)) {
                    ReadPersonsBinary(reader);
                }
            }
            stopwatch.Stop();

            resultWriter.WriteLine($"{stopwatch.ElapsedTicks}");
        }
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
