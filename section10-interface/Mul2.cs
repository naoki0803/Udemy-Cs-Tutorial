namespace section10_interface;

public class Mul2(int num1, int num2) : IMul
{
    private int Num1 { get; set; } = num1;
    private int Num2 { get; set; } = num2;

    public string Calc()
    {
        return $"結果は{Num1 * Num2}です";
    }
}