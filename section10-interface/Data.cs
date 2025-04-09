namespace section10_interface;

public class Data : IReadData, IWriteData
{
    private int _num;
    public Data(int num)
    {
        _num = num;
    }
    public void Read()
    {
        Console.WriteLine($"フィールドは{_num}です");
    }
    public void Write(int num)
    {
        Console.WriteLine($"before: {_num}");
        _num = num;
        Console.WriteLine($"after: {_num}");
    }
}
