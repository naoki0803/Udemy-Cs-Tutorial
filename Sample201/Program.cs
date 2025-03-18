namespace Sample201;

class Program
{
    static void Main(string[] args)
    {
        /* if 分
        */
        var fruit = "いちご";
        if (fruit == "apple")
        {
            Console.WriteLine("りんごです");
        }
        else if (fruit == "banana")
        {
            Console.WriteLine("バナナです");
        }
        else
        {
            Console.WriteLine("りんごか、バナナではありません");
        }
    }
}
