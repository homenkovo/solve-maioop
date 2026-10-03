using System.Xml.Serialization;
using System.Text;
using Core;

namespace Shop.Dal;

public class DaoXmlRepository<T> where T : IPrimary
{
    private static XmlSerializer serializer = new XmlSerializer(typeof(T));

    public string Filename { get; }

    public DaoXmlRepository(string filename)
    {
        Filename = filename;
    }

    public void Create()
    {
        File.Create(Filename).Close();
    }

    public T? Read(long id)
    {
        using (StreamReader reader = File.OpenText(Filename))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                object? temp = serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(line!)));
                if (temp is T tempT && tempT.Id == id)
                {
                    return tempT;
                }
            }
        }

        return default(T);
    }

    public List<T> ReadAll()
    {
        List<T> toReturn = new List<T>();
        using (StreamReader reader = File.OpenText(Filename))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                object? temp = serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(line!)));
                if (temp is T tempT)
                {
                    toReturn.Add(tempT);
                }
            }
        }

        return toReturn;
    }

    public void Update(T updated)
    {
        using (StreamReader reader = new(Filename))
        {
            using (StreamWriter writer = new($"{Filename}.tmp"))
            {
                bool undone = true;
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    object? temp = serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(line!)));
                    if (undone && temp is T tempT && tempT.Id == updated.Id)
                    {
                        undone = false;
                        serializer.Serialize(writer, updated);
                    }
                    else
                    {
                        writer.WriteLine(line!);
                    }
                }

                if (undone)
                {
                    serializer.Serialize(writer, updated);
                }
            }
        }

        File.Move($"{Filename}.tmp", Filename, true);
    }

    public void Delete(long id)
    {
        using (StreamReader reader = new(Filename))
        {
            using (StreamWriter writer = new($"{Filename}.tmp"))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    object? temp = serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(line!)));
                    if (temp is T tempT && tempT.Id != id)
                    {
                        writer.WriteLine(line!);
                    }
                }
            }
        }

        File.Move($"{Filename}.tmp", Filename, true);
    }
}
