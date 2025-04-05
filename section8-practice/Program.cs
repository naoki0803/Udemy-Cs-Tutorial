using section8_practice;

Console.Write("p1.X = ");
double x1 = double.Parse(Console.ReadLine() ?? "0");

Console.Write("p1.Y = ");
double y1 = double.Parse(Console.ReadLine() ?? "0");


Console.Write("p2.X = ");
double x2 = double.Parse(Console.ReadLine() ?? "0");
Console.Write("p2.Y = ");
double y2 = double.Parse(Console.ReadLine() ?? "0");

Point2D p1 = new Point2D(x1, y1);
Point2D p2 = new Point2D(x2, y2);

// 座標の表示
Console.WriteLine($"p1 = {p1}");
Console.WriteLine($"p2 = {p2}");

// Point2Dクラスで ToString メソッドをオーバーライドしていない場合の記述
// Console.WriteLine($"p1 = {p1.X}, {p1.Y}");
// Console.WriteLine($"p2 = {p2.X}, {p2.Y}");


// 距離の計算
double distance = p1.Distance(p2);

// 等価性の確認
if (p1.Equals(p2))
{
    Console.WriteLine("p1とp2は等価です。");
}
else
{
    Console.WriteLine("p1とp2は等価ではありません。");
}