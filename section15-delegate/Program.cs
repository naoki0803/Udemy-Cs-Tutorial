// デリゲート
delegate void Operation(int a, int b);

// Calcクラス
class Calc
{
    public void Sub(int a, int b)
    {
        Console.WriteLine($"CalcクラスのSubメソッドで実行した結果: {a}-{b}={a - b}");
    }
}

class Program
{
    static void Add(int a, int b)
    {
        Console.WriteLine($"static メソッドの Add で実行した結果: {a}+{b}={a + b}");
    }
    static void Main(string[] args)
    {
        Calc c = new Calc();
        Operation o1 = new Operation(Add);
        Operation o2 = new Operation(c.Sub);

        // デリゲートで設定したメソッドの呼び出し
        o1(2, 1);
        o2(2, 1);
    }
}