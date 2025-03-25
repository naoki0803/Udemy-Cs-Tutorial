

/* 配列の初期化
    1. 初期化と代入を別で行う
    型[] 変数名 = new 型[要素数];
    型[0] = 代入値1;
    型[1] = 代入値2;

    2. 初期化と代入を同時に行う
    型[] 変数名 = {値, 値, 値, 値, 値, 値, 値}
*/

// 1. 初期化と代入を別で行う
// double[] arr = new double[3];
// arr[0] = 1.2;
// arr[1] = 3.7;
// arr[2] = 4.1;


// 2. 初期化と代入を同時に行う
double[] arr = { 1.2, 3.7, 4.1 };
double sum, avg;
sum = 0;

// sum = arr.Aggregate((acc, crr) =>
// {
//     return acc + crr;
// });

foreach (double a in arr)
{
    sum += a;
}
avg = sum / arr.Length;
Console.WriteLine($"配列の合計は: {sum}です。");
Console.WriteLine($"配列の平均は: {avg}です。");


string[] strings = { "ABC", "DEF", "GHI" };
string[] newStrings = strings.Select(s => s + s).ToArray();
Console.WriteLine(string.Join(",", newStrings));

foreach (string s in strings)
{
    Console.Write(s);
    Console.Write($"{s},");
}
Console.WriteLine();

int[] numbers = { 1, 2, 3, 4 };
int doubleNum = 0;
foreach (int n in numbers)
{
    doubleNum += n;
}

Console.WriteLine(doubleNum);

// 2次元配列

int[,] matrixArr = { { 1, 2, 3, 4 }, { 4, 5, 6, 7 }, { 7, 8, 9, 10 } };
Console.WriteLine(matrixArr.GetLength(0)); //行数 3
Console.WriteLine(matrixArr.GetLength(1)); //列数 4

for (int i = 0; i < matrixArr.GetLength(0); i++)
{
    for (int j = 0; j < matrixArr.GetLength(1); j++)
    {
        Console.Write($"{matrixArr[i, j]} ");
    }
}
Console.WriteLine(); // 改行を追加



// 練習問題1
int[] array = new int[10];

for (int i = 0; i < array.Length; i++)
{
    array[i] = i + 1;
    Console.WriteLine($"a[{i}] = {i + 1}");
}
Console.WriteLine(string.Join(",", array));


// int[] result =dr

Console.WriteLine(string.Join(",", array.Select(
    (a, idx) => array[idx] = idx + 1)
    .ToArray()
    )
);
// Console.WriteLine(string.Join(",", result));



// 練習問題2
double[] d = { 0.2, 1.4, -0.8 };
for (int i = 0; i < d.Length; i++)
{
    Console.WriteLine($"a[{i}] = {d[i]}");
}

// 練習問題3

Random rnd = new Random();
int[] practiceArr = new int[10];

for (int i = 0; i < practiceArr.Length; i++)
{
    practiceArr[i] = rnd.Next(1, 101);
}

Console.WriteLine(string.Join(",", practiceArr));
Console.WriteLine(practiceArr.Sum());
Console.WriteLine(practiceArr.Average());
Console.WriteLine(practiceArr.Max());
Console.WriteLine(practiceArr.Min());
// 練習問題4
int[,] arr99 = new int[9, 9];

// for (int i = 0; i < arr99.GetLength(0); i++)
// {
//     for (int j = 0; j < arr99.GetLength(1); j++)
//     {
//         arr99[i, j] = j + 1;
//     }
// }
for (int i = 0; i < arr99.GetLength(0); i++)
{
    for (int j = 0; j < arr99.GetLength(1); j++)
    {
        arr99[i, j] = (i + 1) * (j + 1);
        // Console.Write($"{arr99[i, j]} ");
    }
    // Console.WriteLine();
}

// // Console.WriteLine(string.Join(",", arr99));   // 2次元配列のままではConsole.WriteLine();での出力はできない

// arr99.Cast<int>()で、一次元配列に変換し、
// .Select(x => x.ToString()) で文字列に変換
// 戻り値の文字列配列をJoinでカンマ区切りで出力している。
Console.WriteLine(string.Join(",", arr99.Cast<int>().Select(x => x.ToString())));

