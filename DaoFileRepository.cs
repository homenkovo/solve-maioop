using System.Text.Json;

class DaoFileRepository<T> where T : IPrimary {
    public string Filename { get; }

    public DaoFileRepository(string filename) {
        Filename = filename;
    }

    public void Create() {
        File.Create(Filename).Close();
    }

    public T? Read(long id) {
        using (StreamReader reader = File.OpenText(Filename)) {
            string? line;
            while ((line = reader.ReadLine()) != null) {
                T? temp = JsonSerializer.Deserialize<T>(line!);
                if (temp is T tempT && tempT.Id == id) {
                    return tempT;
                }
            }
        }

        return default(T);
    }

    public List<T> ReadAll() {
        List<T> toReturn = new List<T>();
        using (StreamReader reader = File.OpenText(Filename)) {
            string? line;
            while ((line = reader.ReadLine()) != null) {
                T? temp = JsonSerializer.Deserialize<T>(line!);
                if (temp is T tempT) {
                    toReturn.Add(tempT);
                }
            }
        }

        return toReturn;
    }

    public void Update(T updated) {
        using (StreamReader reader = new(Filename)) {
            using (StreamWriter writer = new($"{Filename}.tmp")) {
                bool undone = true;
                string? line;
                while ((line = reader.ReadLine()) != null) {
                    T? temp = JsonSerializer.Deserialize<T>(line!);
                    if (undone && (temp?.Id ?? 0) == updated.Id) {
                        undone = false;
                        writer.WriteLine(JsonSerializer.Serialize(updated));
                    } else {
                        writer.WriteLine(line!);
                    }
                }

                if (undone) {
                    writer.WriteLine(JsonSerializer.Serialize(updated));
                }
            }
        }

        File.Move($"{Filename}.tmp", Filename, true);
    }

    public void Delete(long id) {
        using (StreamReader reader = new(Filename)) {
            using (StreamWriter writer = new($"{Filename}.tmp")) {
                string? line;
                while ((line = reader.ReadLine()) != null) {
                    T? temp = JsonSerializer.Deserialize<T>(line!);
                    if ((temp?.Id ?? 0) != id) {
                        writer.WriteLine(line!);
                    }
                }
            }
        }

        File.Move($"{Filename}.tmp", Filename, true);
    }
}
