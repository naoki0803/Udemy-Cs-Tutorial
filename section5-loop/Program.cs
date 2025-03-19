for (int i = 1; i <= 2; i++)
{
    for (int j = 1; j <= 3; j++)
    {
        int k = i + j;
        Console.Write($"{i}+{j}={k} ");
    }
    Console.WriteLine();
}
/*
1+1=2 1+2=3 1+3=4 
2+1=3 2+2=4 2+3=5 
*/

int[] arr = { 1, 2, 3, 4, 5 };

var newArr = arr.Select(a => a + 1).ToArray();


// 配列を参照する場合、文字列に変換する必要がある。
Console.WriteLine(newArr);  //配列を直接参照できない為、 System.Int32[] と表示される
Console.WriteLine(string.Join(",", newArr));  // 2, 3, 4, 5, 6 と表示される