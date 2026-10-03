using Shop.Dal;

class Program {
    public static void Main() {
        DaoXmlRepository<ShopDao> shops = new DaoXmlRepository<ShopDao>("../tmp/shops.xml");
        DaoXmlRepository<ClientDao> clients = new DaoXmlRepository<ClientDao>("../tmp/clients.xml");
        DaoXmlRepository<GoodDao> goods = new DaoXmlRepository<GoodDao>("../tmp/goods.xml");

        shops.Create();
        for (int i = 0; i < 3; ++i) {
            shops.Update(new ShopDao(i, $"Shop {i}", $"Code {i}"));
        }
    }
}
