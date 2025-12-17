namespace gitSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("test");
            Console.WriteLine("test2");
            Console.ReadLine();
            List<string> list = new List<string> {"a","b","c" };
            
            for (int i = 0; i < list.Count; i++) 
            {
                Console.WriteLine(list[i]);
                Console.ReadLine();

            }
        }
    }
}
