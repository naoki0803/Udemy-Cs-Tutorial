namespace section10_interface;

public class Mul1(int num1, int num2) : IMul
{
    private int Num1 { get; set; } = num1;
    private int Num2 { get; set; } = num2;

    public string Calc()
    {
        int result = 0;

        for (int i = 0; i < Num2; i++)
        {
            result += Num1;
        }
        return $"結果は{result}です";
    }
}