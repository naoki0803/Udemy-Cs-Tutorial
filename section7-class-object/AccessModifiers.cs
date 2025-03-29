namespace section7_class_object;

public class AccessModifiersPerson
{
    // private装飾子が付与されているので、外部からフィールドへ直接アクセスできない。
    private string name;
    private int age;

    // フィールドのセット
    public void SetAgeAndName(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // フィールドの表示
    public void ShowAgeAndName()
    {
        Console.WriteLine($"Nameは{Name},年齢は{Age}");
    }

    // コンストラクタ
    public AccessModifiersPerson(string name, int age)
    {
        Name = name;
        Age = age;
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
