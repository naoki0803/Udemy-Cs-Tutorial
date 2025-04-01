namespace section7_class_object
{
    class Destructor
    {
        // コンストラクター
        public Destructor()
        {
            Console.WriteLine("コンストラクタが呼び出されました");
        }
        // デストラクター
        ~Destructor()
        {
            Console.WriteLine("デストラクタが呼び出されました");
        }
    }
}