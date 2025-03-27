// using ConsoleApp1; // Person クラスが定義されている名前空間を追加

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

