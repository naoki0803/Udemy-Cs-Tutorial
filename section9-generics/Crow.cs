namespace section9_generics;

public class Crow(string name)
{
    public string Name { get; } = name;

    public void Sing()
    {
        Console.WriteLine($"{Name}は、カーカーと鳴きました。");
    }
}
