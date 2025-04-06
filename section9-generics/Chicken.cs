namespace section9_generics;

public class Chicken(string name) : Bird(name)
{
    public override string Name => _name;

    public override void Sing()
    {
        Console.WriteLine($"{Name}は、コケコッコーと鳴きました。");
    }
}
