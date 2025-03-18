namespace Sample201;

class Program
{
    static void Main(string[] args)
    {
        // 数字入力判定
        Console.Write("サイコロの目｢1〜6｣を入力してください: ");
        int dice = int.Parse(Console.ReadLine());
        if (dice <= dice && dice <= 6)
        {
            if (dice % 2 == 0)
            {
                Console.WriteLine("偶数です");
            }
            else
            {
                Console.WriteLine("奇数です");
            }
        }
        else
        {
            Console.WriteLine("1〜6を入力してください");
        }

        // 文字列判定
        string fruit = "いちご";
        if (fruit == "apple")
        {
            Console.WriteLine("りんごです");
        }
        else if (fruit == "banana")
        {
            Console.WriteLine("バナナです");
        }
        else
        {
            Console.WriteLine("りんごか、バナナではありません");
        }

        /* switch 文
            基本的な記述方法は JavaScript と同じ
            注意点として、フォールスルーの処理は構文エラーになる
        */
        Console.Write("1から3の整数を入力:");
        int num = int.Parse(Console.ReadLine());
        switch (num)
        {
            case 1:
            case 9: // caseを2つ指定することも可能
                Console.WriteLine("1 or 9 です");
                break;
            case 2:
                Console.WriteLine("2 です");
                break;
            case 3:
                Console.WriteLine("3 です");
                break;
            default:
                Console.WriteLine("1から3 もしくは 9 の整数を入力してください。");
                break;
        }


        // 練習問題1
        Console.Write("数値を入力してください。");
        double temp = double.Parse(Console.ReadLine());
        if (temp == 0)
        {
            Console.WriteLine("ゼロ");
        }
        else if (temp > 0)
        {
            Console.WriteLine("プラス");
        }
        else
        {
            Console.WriteLine("マイナス");
        }

        // 練習問題1
        Console.Write("Hello と入力してください");
        string hello = Console.ReadLine();

        Console.Write("World と入力してください");
        string world = Console.ReadLine();

        if (hello == "Hello" && world == "World")
        {
            Console.WriteLine("Good");
        }
        else
        {
            Console.WriteLine("hello word please!");
        }
    }
}