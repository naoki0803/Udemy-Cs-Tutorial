namespace section7_class_object;

public class AccessModifiersPerson
{
    // private装飾子が付与されているので、外部からフィールドへ直接アクセスできない。
    public string name;
    public int age;

    // フィールドのセット
    public void SetAgeAndName(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // フィールドの表示
    public void ShowAgeAndName(string name, int age)
    {
        Console.WriteLine($"{name}, {age}");
    }

    // コンストラクター
    public AccessModifiersPerson(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // プロパティのSetterとGetter
    // SetterとGetterを定義することで、プロパティに対して外部からの編集/参照を定義できる。
    public string Name
    {
        set { name = value; }
        get { return name; }
    }
    public int Age
    {
        set { age = value; }
        get { return age; }
    }
}
