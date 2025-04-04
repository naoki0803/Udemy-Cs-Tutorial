namespace section8_inheritance;

public class ParentCalc
{
    protected int num1;
    protected int num2;

    public ParentCalc(int num1, int num2)
    {
        this.num1 = num1;
        this.num2 = num2;
    }

    public int Num1
    {
        get { return num1; }
        set { num1 = value; }
    }

    public int Num2
    {
        get { return num2; }
        set { num2 = value; }
    }
    public int Add()
    {
        Console.Write("ParentCalcのAddメソッド: ");
        return num1 + num2;
    }

    public int Sub()
    {
        return num1 - num2;
    }
}
