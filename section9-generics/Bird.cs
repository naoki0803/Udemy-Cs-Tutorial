namespace section9_generics;

// public class Bird(string name)

// abstract を付けると、抽象クラスとして実装される
public abstract class Bird(string name)
{
    protected readonly string _name = name;
    /* 
        象プロパティ
        派生クラスで override して必ず実装する必要がある
    */

    public abstract string Name { get; }

    /*
    以下のように = name; を記述すると、実装を記述することになりコンパイルエラーになる。
    abstract をつけたプロパティは、派生クラスで override して必ず実装する必要がある。
    */
    // public abstract string Name { get; } = name;

    /* 
        抽象メソッド
        派生クラスで override して必ず実装する必要がある
    */
    public abstract void Sing();
}
