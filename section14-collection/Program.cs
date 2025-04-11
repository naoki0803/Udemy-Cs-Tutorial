List<int> list = new List<int>();

list.Add(1);
list.Add(2);
list.Add(3);

Console.WriteLine(list);

list.Insert(0, 4);


// list の様々な出力方法
Console.WriteLine(string.Join("\n", list)); // 改行
Console.WriteLine(string.Join(" ", list));  // 半角スペース
foreach (var item in list)                  // foreach で愚直に
{
    Console.WriteLine(item);
}



List<String> names = new List<String>() { "Taro", "Hanako", "Jiro", "kaoru", "Taro" };
Console.WriteLine($"削除前: {string.Join(" ", names)}");

// Remove は完全位置ではじめに見つかった要素を削除
names.Remove("Taro");
Console.WriteLine($"削除後1: {string.Join(" ", names)}");

// 部分一致では削除されない
names.Remove("Hana");
Console.WriteLine($"削除後2: {string.Join(" ", names)}");

// 指定したindexの要素を削除
names.RemoveAt(names.Count - 1);
Console.WriteLine($"最後の要素を削除: {string.Join(" ", names)}");


int[] numbers = { 1, 2, 3, 4, 5 };


/*
    ディクショナリ
    javascriptのオブジェクトと同じようなものです。
*/
//人口
Dictionary<string, int> population = new Dictionary<string, int>()
{
    { "Japan", 1396 },
    { "China", 1392 },
    { "India", 1326 },
    { "Indonesia", 1207 },
    { "Pakistan", 1176 },
    { "Bangladesh", 1164 }
};

foreach (var item in population)
{
    Console.WriteLine($"{item.Key}の人口は{item.Value}万人です。");
}


Dictionary<string, string> capital = new Dictionary<string, string>()
{
    { "日本", "東京" },
    { "イギリス", "ロンドン" },
    { "フランス", "パリ"  },
    { "中国", "北京" }
};

foreach (var item in capital)
{
    Console.WriteLine($"{item.Key}の首都は{item.Value}です。");
}

// 練習問題 1
// List<int> Numbers = new List<int>();

// while (true)
// {
//     Console.Write("1〜10の値を入力してください: ");
//     int inputNum = int.Parse(Console.ReadLine());
//     // 1~10以外の数値を入力したら終了する
//     if (inputNum < 1 || inputNum > 10)
//     {
//         break;
//     }
//     Numbers.Add(inputNum);
// }

// Console.WriteLine(string.Join(" ", Numbers));
// Console.WriteLine(Numbers.Max());
// Console.WriteLine(Numbers.Min());


// 練習問題 2
HashSet<int> HashNumbers = new HashSet<int>();

while (true)
{
    Console.Write("1〜10の値を入力してください: ");
    int inputNum = int.Parse(Console.ReadLine());
    // 1~10以外の数値を入力したら終了する
    if (inputNum < 1 || inputNum > 10)
    {
        break;
    }
    HashNumbers.Add(inputNum);
}

Console.WriteLine(string.Join(" ", HashNumbers));
Console.WriteLine(string.Join(" ", HashNumbers.OrderBy(n => n)));
Console.WriteLine(string.Join(" ", HashNumbers.Order()));

// 練習問題 3
Dictionary<string, int> Months = new Dictionary<string, int>()
{
    {"January", 1},
    {"February", 2},
    {"March", 3},
    {"April", 4},
    {"May", 5},
    {"June", 6},
    {"July", 7},
    {"August", 8},
    {"September", 9},
    {"October", 10},
    {"November", 11},
    {"December", 12},
};

Console.Write("英語で月を入力してください: ");
string inputValue = Console.ReadLine();

Console.WriteLine($"入力した月は{Months[inputValue]}月です");


// ディクショナリの定義バリエーション
// 愚直に代入Version
Dictionary<string, int> Months2 = new Dictionary<string, int>();
Months2["January"] = 1;
Months2["February"] = 2;
Months2["March"] = 3;
Months2["April"] = 4;
Months2["May"] = 5;
Months2["June"] = 6;
Months2["July"] = 7;
Months2["August"] = 8;
Months2["September"] = 9;
Months2["October"] = 10;
Months2["November"] = 11;
Months2["December"] = 12;

// 配列からループで代入
string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

// 配列からループで代入:1 foreachを使うVersion
Dictionary<string, int> Months4 = new Dictionary<string, int>();
int idx = 1;
foreach (var item in months)
{
    Months4[item] = idx;
    idx++;
}

// 配列からループで代入:2 Selectを使うVersion
Dictionary<string, int> Months3 = new Dictionary<string, int>();
Months3 = months.Select((m, idx) => new { Key = m, Value = idx + 1 }).ToDictionary(x => x.Key, x => x.Value);