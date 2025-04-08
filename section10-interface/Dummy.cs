namespace section10_interface;

public class Dummy : IFunc1, IFunc2
{
    public void Moge() { Console.WriteLine("Mogeが実行されました。"); }
    public void Huga() { Console.WriteLine("Hugaが実行されました。"); }
    public void Hoge() { Console.WriteLine("Hogeが実行されました。"); }
}
