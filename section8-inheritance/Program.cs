using section8_inheritance;

ParentCalc parentCalc = new ParentCalc(10, 20);
ChildCalc childCalc = new ChildCalc(30, 20);

Console.WriteLine($"親クラスAdd:{parentCalc.Add()}");
Console.WriteLine($"親クラスSub:{parentCalc.Sub()}");
Console.WriteLine($"子クラスAdd:{childCalc.Add()}");
Console.WriteLine($"子クラスSub:{childCalc.Sub()}");
Console.WriteLine($"子クラスMul:{childCalc.Mul()}");
Console.WriteLine($"子クラスDiv:{childCalc.Div()}");

/*  
    親クラスで virtual を宣言しているので、
    子クラスで override したメソッドが呼び出される 
        ※ override は親クラスで virtual を宣言しているメソッドに対してのみ有効で、 
        virtual の記述がない場合はコンパイルエラーになる
*/
ParentCalc OverlordCalc = new ChildCalc(30, 20);
Console.WriteLine($"子クラスAdd:{childCalc.Add()}");
Console.WriteLine($"overrideしたAdd:{OverlordCalc.Add()}");


/*
    オブジェクトクラス
    全てのクラスはObjectClassを継承しており、ObjectClassのメソッドを使用できる
*/
Program s = new Program();
Program s2 = new Program();

// ObjectClassの.ToString()メソッドを呼び出すと、オブジェクトの文字列表現を取得できる
Console.WriteLine(s.ToString());

// ObjectClassのEqualsメソッドを呼び出すと、オブジェクトの等価性を確認できる
Console.WriteLine(s.Equals(s2));
Console.WriteLine(s.Equals(s));

// ObjectClassの.GetHashCode()メソッドを呼び出すと、オブジェクトのハッシュコードを取得できる
Console.WriteLine(s.GetHashCode());
Console.WriteLine(s2.GetHashCode());

// ObjectClassの型
Console.WriteLine(s.GetType());

// ObjectClassの.GetType()メソッドを呼び出すと、オブジェクトの型を取得できる
Console.WriteLine(s.GetType());

// ObjectClassの.MemberwiseClone()メソッドを呼び出すと、オブジェクトの浅いコピーを作成できる
Program s3 = (Program)s.MemberwiseClone();
Console.WriteLine(s3.ToString());
