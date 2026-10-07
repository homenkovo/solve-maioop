using Shop.Dal;

class Program
{
    public static void Main()
    {
        Directory.CreateDirectory("../tmp");

        DaoXmlRepository<ShopDao> shopsXml = new DaoXmlRepository<ShopDao>("../tmp/shops.xml");
        DaoXmlRepository<ClientDao> clientsXml = new DaoXmlRepository<ClientDao>("../tmp/clients.xml");
        DaoXmlRepository<GoodDao> goodsXml = new DaoXmlRepository<GoodDao>("../tmp/goods.xml");

        DaoJsonRepository<ShopDao> shopsJson = new DaoJsonRepository<ShopDao>("../tmp/shops.json");
        DaoJsonRepository<ClientDao> clientsJson = new DaoJsonRepository<ClientDao>("../tmp/clients.json");
        DaoJsonRepository<GoodDao> goodsJson = new DaoJsonRepository<GoodDao>("../tmp/goods.json");

        shopsXml.Create();
        shopsJson.Create();
        for (int i = 0; i < 3; ++i)
        {
            ShopDao shop = new ShopDao(i, $"Shop {i}", $"Code {i}");
            shopsXml.Update(shop);
            shopsJson.Update(shop);
        }

        clientsXml.Create();
        clientsJson.Create();
        for (int i = 0; i < 5; ++i)
        {
            ClientDao client = new ClientDao(i, $"Name {i}", $"LastName {i}", $"Patronymic {i}", new DateOnly());
            clientsXml.Update(client);
            clientsJson.Update(client);
        }

        goodsXml.Create();
        goodsJson.Create();
        for (int i = 0; i < 30; ++i)
        {
            GoodDao good = new GoodDao(i, $"Good {i}", $"Code {i}", 10);
            goodsXml.Update(good);
            goodsJson.Update(good);
        }

        List<ShopDao> shops = shopsXml.ReadAll()!;
        foreach (ShopDao shop in shops)
        {
            Console.WriteLine(shop.Id);
        }
    }
}
