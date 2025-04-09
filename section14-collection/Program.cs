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
