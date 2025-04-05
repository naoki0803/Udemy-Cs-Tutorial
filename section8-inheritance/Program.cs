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
