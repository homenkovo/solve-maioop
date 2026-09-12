using static Utils;

class Program {
    private static string GOODS_FILENAME = "goods.txt";
    private static string CLIENTS_FILENAME = "clients.txt";
    private static string SHOPS_FILENAME = "shops.txt";

    public static void Main(string[] args) {
        if (args.Length == 1) {
            if (args[0] == "--test-person") {
                TestPerson("output.csv", new int[]{10, 1000, 100000, 1000000});
            } if (args[0] == "--test-shop") {
                WriteGoods(GOODS_FILENAME, Utils.InitGoods(20));
                WriteClients(CLIENTS_FILENAME, Utils.InitClients(5));
                WriteShops(SHOPS_FILENAME, Utils.InitShops(3));

                Good[] goods = ReadGoods(GOODS_FILENAME)!;
                Array.Resize(ref goods, goods.Length + 10);
                for (int i = 20; i < goods.Length; ++i) {
                    goods[i] = new Good($"Name #{i}", $"Code #{i}", i);
                }
                WriteGoods(GOODS_FILENAME, goods);

                Client[] clients = ReadClients(CLIENTS_FILENAME)!;
                Array.Resize(ref clients, clients.Length + 3);
                for (int i = 5; i < clients.Length; ++i) {
                    clients[i] = new Client($"Name #{i}", $"Surname #{i}", new DateOnly(1900, 1, 1));
                }
                WriteClients(CLIENTS_FILENAME, clients);

                Shop[] shops = ReadShops(SHOPS_FILENAME)!;
                Array.Resize(ref shops, shops.Length + 2);
                for (int i = 3; i < shops.Length; ++i) {
                    shops[i] = new Shop($"Name {i}", $"CODE10{i}");
                }
                WriteShops(SHOPS_FILENAME, shops);
            }
        }
    }
}
