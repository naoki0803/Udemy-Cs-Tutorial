namespace section9_generics;


// public class Sparrow(string name)   //継承前の記述
public class Sparrow() : Bird("すずめ")
{
    // public string Name { get; } = name;

    // public void Sing()
    public override void Sing()
    {
        Console.WriteLine($"{Name}は、チュンチュンと鳴きました。");
    }
}
