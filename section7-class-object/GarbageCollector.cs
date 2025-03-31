namespace section7_class_object;

public class GarbageCollector
{
    public void RunDemo()
    {
        String[] a = new String[1000];
        for (int i = 0; i < 1000; i++)
        {
            a[i] = new string('M', 1000);
        }

        Console.WriteLine($"GC未実行時メモリ使用量: {GC.GetTotalMemory(false)}");
        a = null;       // aの参照を開放
        Console.WriteLine($"aの参照解放直後: {GC.GetTotalMemory(false)}");
        GC.Collect();   // 手動でGCを実行
        Console.WriteLine($"GC実行後のメモリ使用量: {GC.GetTotalMemory(false)}");
    }
}