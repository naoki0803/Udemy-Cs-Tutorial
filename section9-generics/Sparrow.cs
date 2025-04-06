namespace section9_generics;


// public class Sparrow(string name)   //継承前の記述
public class Sparrow() : Bird("すずめ")
{
    public override string Name => _name;
    /*
        上記コードは以下をラムダ式で記述している    
        public override string Name
        {
            get { return _name; }
        }

        また、自動実装プロパティでは、以下の記述は構文エラーとなる。
        public override string Name { get; } = _name;
    */

    // public void Sing()
    public override void Sing()
    {
        Console.WriteLine($"{Name}は、チュンチュンと鳴きました。");
    }
}
