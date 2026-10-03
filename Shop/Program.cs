using Shop.Dal;

class Program {
    public static void Main() {
        DaoFileRepository<GoodDao> goodDaoFileRepository = new("goods.txt");
    }
}
