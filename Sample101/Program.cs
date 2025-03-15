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


/* キャスト
異なる type 同士で変数を代入する際に利用する
*/

int intNum;
// intNum = 1.23;  // intにdoubleの代入はキャストしないとエラーになる
intNum = (int)1.23;
Console.WriteLine(intNum); //1.23 は 1 として整数で代入される

double doubleNum;
doubleNum = 1;  // これは代入可能で 1 として代入される。
Console.WriteLine(doubleNum);


/* ユーザーの入力による代入

*/

string inputValue1, inputValue2;
Console.Write("苗字を入力してください => ");
inputValue1 = Console.ReadLine();
Console.Write("名字を入力してください => ");
inputValue2 = Console.ReadLine();
Console.WriteLine($"あなたの名前は{inputValue1} {inputValue2}:です");