namespace section9_generics;

public class Sparrow(string name)
{
    public string Name { get; } = name;

    public void Sing()
    {
        Console.WriteLine($"{Name}は、チュンチュンと鳴きました。");
    }
}
