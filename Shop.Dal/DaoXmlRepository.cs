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
        List<T>? temp = ReadAll();
        if (temp is List<T> tempT)
        {
            foreach (T i in temp)
            {
                if (i.Id == id)
                {
                    return i;
                }
            }
        }

        return default(T);
    }

    public List<T>? ReadAll()
    {
        using (StreamReader reader = File.OpenText(Filename))
        {
            object? temp = serializer.Deserialize(reader);
            if (temp is List<T> tempT)
            {
                return tempT
            }
        }

        return null;
    }

    public void Update(T updated)
    {
        List<T>? temp = ReadAll();
        if (temp is List<T> tempT)
        {
            foreach (T i in temp)
            {
                if (i.Id == id)
                {
                    return i;
                }
            }
        }

        return default(T);
    }

    public void Delete(long id)
    {
        List<T>? temp = ReadAll();
        if (temp is List<T> tempT)
        {
            foreach (T i in temp)
            {
                if (i.Id == id)
                {
                    tempT.Remove(i);
                }
            }
        }
    }
}
