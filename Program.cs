using static Utils;

class Program {
    private static string GOODS_FILENAME = "goods.txt";
    private static string CLIENTS_FILENAME = "clients.txt";
    private static string SHOPS_FILENAME = "shops.txt";

    public static void Main(string[] args) {
        if (args.Length == 1 && args[0] == "--test-shops") {
            Utils.WriteGoods(GOODS_FILENAME, Utils.InitGoods(20));
            Utils.WriteClients(CLIENTS_FILENAME, Utils.InitClients(5));
            Utils.WriteShops(SHOPS_FILENAME, Utils.InitShops(3));

            Good[] goods = Utils.ReadGoods(GOODS_FILENAME)!;
            Array.Resize(ref goods, goods.Length + 10);
            for (int i = 20; i < goods.Length; ++i) {
                goods[i] = new Good($"Name #{i}", $"Code #{i}", i);
            }
            Utils.WriteGoods(GOODS_FILENAME, goods);

            Client[] clients = Utils.ReadClients(CLIENTS_FILENAME)!;
            Array.Resize(ref clients, clients.Length + 3);
            for (int i = 5; i < clients.Length; ++i) {
                clients[i] = new Client($"Name #{i}", $"Surname #{i}", new DateOnly(1900, 1, 1));
            }
            Utils.WriteClients(CLIENTS_FILENAME, clients);

            Shop[] shops = Utils.ReadShops(SHOPS_FILENAME)!;
            Array.Resize(ref shops, shops.Length + 2);
            for (int i = 3; i < shops.Length; ++i) {
                shops[i] = new Shop($"Name {i}", $"CODE10{i}");
            }
            Utils.WriteShops(SHOPS_FILENAME, shops);
        }
    }
}
