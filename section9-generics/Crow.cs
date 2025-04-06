namespace section9_generics;


// public class Crow(string name)   //継承前の記述
public class Crow() : Bird("カラス")
{
    // public string Name { get; } = name;

    // public void Sing()
    public override void Sing()
    {
        Console.WriteLine($"{Name}は、カーカーと鳴きました。");
    }
}
