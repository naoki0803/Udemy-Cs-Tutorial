
static int getNum(int idx)
{
    int[] numbers = { 1, 2, 3, 4, 0 };  //IndexOutOfRangeExceptionが発生する
    // int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
    return numbers[idx];
}

static int Calc(int a, int b)
{
    return a / b;
}

try
{

    for (int i = 0; i <= 4; i++)
    {
        int a = getNum(i);
        int b = 5;
        Console.WriteLine($"{a}/{b}={Calc(a, b)}");

    }
    throw new IndexOutOfRangeException();
    throw new DivideByZeroException();


}

catch (DivideByZeroException)
{
    Console.WriteLine("0除算が実行されました");
}
catch (IndexOutOfRangeException e)
{
    Console.WriteLine("配列の範囲外にアクセスしました");
    // Console.WriteLine(e);
}
finally
{
    Console.WriteLine("処理を終了します");

}