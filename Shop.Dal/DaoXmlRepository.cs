using System.Xml.Serialization;
using System.Text;
using Core;

namespace Shop.Dal;

public class DaoXmlRepository<T> where T : IPrimary
{
    private static XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

    public string Filename { get; }

    public DaoXmlRepository(string filename)
    {
        Filename = filename;
    }

    public void Create()
    {
        using (StreamWriter writer = new(Filename))
        {
            serializer.Serialize(writer, new List<T>());
        }
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
        using (StreamReader reader = new(Filename))
        {
            object? temp = serializer.Deserialize(reader);
            if (temp is List<T> tempT)
            {
                return tempT;
            }
        }

        return null;
    }

    public void Update(T updated)
    {
        List<T>? temp = ReadAll();
        if (temp is List<T> tempT)
        {
            bool notFound = true;
            for (int i = 0; i < tempT.Count; ++i)
            {
                if (tempT[i].Id == updated.Id)
                {
                    tempT[i] = updated;
                    notFound = false;
                }
            }

            if (notFound)
            {
                tempT.Add(updated);
            }

            using (StreamWriter writer = new(Filename))
            {
                serializer.Serialize(writer, tempT);
            }
        }
    }

    public void Delete(long id)
    {
        List<T>? temp = ReadAll();
        if (temp is List<T> tempT)
        {
            tempT.RemoveAll(x => x.Id == id);
            using (StreamWriter writer = new(Filename))
            {
                serializer.Serialize(writer, tempT);
            }
        }
    }
}
