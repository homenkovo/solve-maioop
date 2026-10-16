using Shop.Dal;

class Program
{
    public static void Main()
    {
        Directory.CreateDirectory("../tmp");

        DaoXmlRepository<ShopDao> shopsXml = new("../tmp/shops.xml");
        DaoXmlRepository<ClientDao> clientsXml = new("../tmp/clients.xml");
        DaoXmlRepository<GoodDao> goodsXml = new("../tmp/goods.xml");

        DaoJsonRepository<ShopDao> shopsJson = new("../tmp/shops.json");
        DaoJsonRepository<ClientDao> clientsJson = new("../tmp/clients.json");
        DaoJsonRepository<GoodDao> goodsJson = new("../tmp/goods.json");

        ShopContext context = new("../tmp/shops.db");
        ShopDaoDataBaseRepository shopsDb = new(context);
        ClientDaoDataBaseRepository clientsDb = new(context);
        GoodDaoDataBaseRepository goodsDb = new(context);

        shopsXml.Create();
        shopsJson.Create();
        shopsDb.Create();
        for (int i = 1; i <= 3; ++i)
        {
            ShopDao shop = new ShopDao(i, $"Shop {i}", $"Code {i}");
            shopsXml.Update(shop);
            shopsJson.Update(shop);
            shopsDb.Update(shop);
        }

        clientsXml.Create();
        clientsJson.Create();
        clientsDb.Create();
        for (int i = 1; i <= 5; ++i)
        {
            ClientDao client = new ClientDao(i, $"Name {i}", $"LastName {i}", $"Patronymic {i}", new DateOnly());
            clientsXml.Update(client);
            clientsJson.Update(client);
            clientsDb.Update(client);
        }

        goodsXml.Create();
        goodsJson.Create();
        goodsDb.Create();
        for (int i = 1; i <= 30; ++i)
        {
            GoodDao good = new GoodDao(i, $"Good {i}", $"Code {i}", 10);
            goodsXml.Update(good);
            goodsJson.Update(good);
            goodsDb.Update(good);
        }
    }
}
