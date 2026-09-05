class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 1 && args[0] == "--test-person") {
            Utils.TestPerson("output.csv", new int[]{10, 1000, 100000 , 1000000, 10000000, 100000000});
        }
    }
}
