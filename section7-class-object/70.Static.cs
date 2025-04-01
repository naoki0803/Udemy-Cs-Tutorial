
namespace section7_class_object
{
    public class StaticData
    {
        // 静的フィールド オブジェクトの数
        private static int count = 0;

        // インスタンスフィールド オブジェクトのID
        private int id;

        public StaticData(int id)
        {
            this.id = id;
            count++;
            Console.WriteLine($"オブジェクトのid:{id} /オブジェクト数:{count}");
        }

        public static void Show()
        {
            Console.WriteLine($"オブジェクトの数は{count}です。");
        }


    }
}