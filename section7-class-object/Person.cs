namespace section7_class_object;    // これを記述するとProgram.csと別の名前空間になるため、Program.csで using を記述する必要がある。
public class Person
{
    public string name = "初期値太郎";
    public int age = 0;


    // class名と同一でメソッドを定義することで、コンストラクタ関数を定義することができる。
    // コンストラクタ関すは、new 演算子を利用してインスタンス化した時に実行する処理

    // 引数無しのコンストラクタ
    // ()のあとに  : this("引数", 引数) と記述することで、デフォルト値を設定可能
    public Person() : this("名無し", 0)
    {
        Console.WriteLine($"引数無しのコンストラクタ => name:{name}, age: {age}");
    }

    // 引数有りのコンストラクター(オーバーライド)
    // 引数に `引数 = 値1` と記述することでデフォルト値を設定可能 (今回は引数無しのコンストラクタ関数も定義しているので意味はない)
    public Person(string name = "名無し？？？", int age = 3000)
    {
        this.name = name;
        this.age = age;
        Console.WriteLine($"引数有りのコンストラクター => name:{name}, age:{age}");
    }

    public void ShowAgeAndName()
    {
        Console.WriteLine($"名前:{name} 年齢:{age}");
    }
    public void SetAgeAndName(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}