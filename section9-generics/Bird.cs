namespace section9_generics;

// public class Bird(string name)

// abstract を付けると、抽象クラスとして実装される
public abstract class Bird(string name)
{
    public string Name { get; } = name;

    public abstract void Sing();
}
