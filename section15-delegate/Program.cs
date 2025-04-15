// デリゲートとは
// C#においてデリゲートはメソッドへの参照を保持するための型です。
// デリゲートを使うことで、メソッドを変数として扱ったり、引数として渡したり、戻り値として返したりすることができます。
// デリゲートは特定のシグネチャ（引数の型と数、戻り値の型）を持つメソッドのみを参照できます。
// イベント駆動型プログラミングやコールバック機能の実装に役立ちます。


// デリゲートの宣言
delegate void Operation(int a, int b);
delegate void Action(int a);

class Calc
{
    public void Sub(int a, int b)
    {
        Console.WriteLine($"CalcクラスのSubメソッドで実行した結果: {a}-{b}={a - b}");
    }
    public static void Add(int a, int b)
    {
        Console.WriteLine($"static メソッドの Add で実行した結果: {a}+{b}={a + b}");
    }
}

class Program
{
    static void Add(int a, int b)
    {
        Console.WriteLine($"static メソッドの Add で実行した結果: {a}+{b}={a + b}");
    }

    static void Func1(int a)
    {
        Console.WriteLine($"Func1の結果: {a}");
    }
    static void Func2(int a)
    {
        Console.WriteLine($"Func1の結果: {a * 2}");
    }
    static void Func3(int a)
    {
        Console.WriteLine($"Func1の結果: {a * 3}");
    }


    static void Main(string[] args)
    {
        Calc c = new Calc();
        Operation o1 = new Operation(Calc.Add);
        Operation o2 = new Operation(Add);
        Operation o3 = new Operation(c.Sub);

        // デリゲートで設定したメソッドの呼び出し
        o1(2, 1);   // static メソッドの Add で実行した結果: 2+1=3
        o2(2, 1);   // static メソッドの Add で実行した結果: 2+1=3
        o3(2, 1);   // CalcクラスのSubメソッドで実行した結果: 2-1=1

        // デリゲートのマルチキャスト
        // デリゲートのインスタンスに複数のメソッドを追加し、メソッドを順番に実行することができる。
        Action a = new Action(Func1);
        a += new Action(Func2);
        a += new Action(Func3);
        a(2);   // 2, 4, 6 の順番で実行される
    }
}