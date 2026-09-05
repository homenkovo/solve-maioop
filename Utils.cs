using System.Text.Json;

class Utils
{
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
}
