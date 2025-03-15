// See https://aka.ms/new-console-template for more information


/* Console への出力
Console.Write は改行無しで出力
Console.WriteLine は改行して出力
*/
Console.Write("H");
Console.Write("e");
Console.Write("l");
Console.Write("l");
Console.Write("o");
Console.Write(",");
Console.WriteLine("World!");
//上記出力結果: Hello,World!


/* 変数宣言
変数宣言は type 変数名 = 値; と記述をする
*/
int a = 3;
int b = 10;
double avg = (a + b) / 2.0; //2.0 と表現しないと整数として値を返してしまう。。。
string firstName = "鈴木", lastName = "太郎";   // 1つのTypeに複数

Console.WriteLine(a);
Console.WriteLine(firstName, lastName);
Console.WriteLine(avg);

