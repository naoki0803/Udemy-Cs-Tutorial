// namespace section7_class_object;

/* オーバーライド
    引数の数や戻り値のみ異なる、同一関数名を作成すること。
    呼び出し時は引数の数が異なる等するとコンパイルエラーとなる。
*/

public class Calc
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}
