using section7_class_object; // section7_class_object クラスが定義されている名前空間を追加

// using static Calc;
// using static Person;

// インスタンス化
Person taro = new Person();

// class 内で初期化された値が表示される
Console.WriteLine(taro.name);   // 初期値太郎
Console.WriteLine(taro.age);    // 0

// 値を代入
taro.name = "太郎";
taro.age = 39;

// 代入した値が表示される
Console.WriteLine(taro.name);   // 太郎
Console.WriteLine(taro.age);    // 39

// class内で定義したメソッドで値を代入する
taro.SetAgeAndName("鈴木一郎", 40);
Console.WriteLine(taro.name);   // 鈴木一郎
Console.WriteLine(taro.age);    // 40

// class内で定義したメソッドで結果が表示される
taro.ShowAgeAndName();   //名前:鈴木一郎 年齢:40


Calc cal = new Calc();
Console.WriteLine(cal.Add(1, 2));
Console.WriteLine(cal.Add(1, 2, 3));
// 4つ目の引数は存在しないため、コンパイルエラーになります。
// Console.WriteLine(cal.Add(1, 2, 3, 4)); 


// コンストラクタ関数でkondをインスタンス化
AccessModifiersPerson kondo = new AccessModifiersPerson("近藤", 20);

// Nameプロパティの参照(getter)
Console.WriteLine(kondo.Name);
// Nameプロパティの変更(setter)
kondo.Name = "kondo";

Console.WriteLine(kondo.Name);

// コンストラクタ関数でAutoPropertyをインスタンス化
AutoImplementProperty AutoProperty = new AutoImplementProperty("自動プロパティ君", 44);

// Nameプロパティの参照(getter)
Console.WriteLine(AutoProperty.Name);

// AutoImplementPropertyの Name プロパティは、 private set; get; としており、変更ができない
// AutoProperty.Name = "kondo";  // コンパイルエラーになる為コメントアウト

Console.WriteLine(AutoProperty.Name);

// 練習問題1
Practice1Vector2D v1 = new Practice1Vector2D(1, 1);
Practice1Vector2D v2 = new Practice1Vector2D(1, -1);
v1.Add(v2);
Console.WriteLine($"{v1.X}, {v1.Y}");
v1.Sub(v2);
Console.WriteLine($"{v1.X}, {v1.Y}");
v1.Mul(2.0);
Console.WriteLine($"{v1.X}, {v1.Y}");
double resolute = v1.DotProduct(v2);
Console.WriteLine(resolute);

GarbageCollector gc = new GarbageCollector();
gc.RunDemo();

// デストラクターの実行(destructorの挙動は確認できず)
Destructor d = new Destructor();


// StaticDataを持つ要素数3の配列を作成
StaticData[] data = new StaticData[3];

// インスタンス化前のクラスメソッドを利用して、フィールドの値を表示可能な事を確認
StaticData.Show();

// インスタンス化
for (int i = 0; i < data.Length; i++)
{
    data[i] = new StaticData(i);
}

// インスタンス化後のクラスメソッドを利用して、参照しているフィールドの値が共通である事を確認
StaticData.Show();