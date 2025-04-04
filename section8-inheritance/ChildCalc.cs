namespace section8_inheritance;

public class ChildCalc : ParentCalc
{
    public ChildCalc(int num1, int num2) : base(num1, num2)
    {
    }
    public int Add()
    {
        Console.Write("ChildCalcのAddメソッド: ");
        return num1 + num2;
    }

    public int Mul()
    {
        return num1 * num2;
    }

    public int Div()
    {
        return num1 / num2;
    }

}
