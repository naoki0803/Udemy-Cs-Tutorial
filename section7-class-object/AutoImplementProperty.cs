namespace section7_class_object;

public class AutoImplementProperty
{
    // private装飾子が付与されているので、外部からフィールドへ直接アクセスできない。
    // private string name;
    // private int age;

    // フィールドのセット
    public void SetAgeAndName(string name, int age)
    {
        Name = name;    // フィールド(this.name)から、プロパティ(Name)に変更
        Age = age;      // フィールド(Age)から、プロパティ(Age)に変更
    }

    // フィールドの表示
    public void ShowAgeAndName(string name, int age)
    {
        Console.WriteLine($"{name}, {age}");
    }

    // コンストラクター
    public AutoImplementProperty(string name, int age)
    {
        /* カプセル化を実施したので、コンストラクタ関数も、フィールドからプロパティへ変更 */
        // this.name = name;
        // this.age = age;
        Name = name;
        Age = age;
    }

    // 自動実装プロパティを利用することでコードを簡潔にすることができる。
    public string Name
    {
        // set { name = value; }
        // get { return name; }

        // 以下のように省略して記述が可能
        private set; get;
    }
    public int Age
    {
        // set { age = value; }
        // get { return age; }

        set; get;
    }
}
