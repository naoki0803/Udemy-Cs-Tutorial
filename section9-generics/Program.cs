using section9_generics;

Crow c = new("カラス");
Sparrow s = new("すずめ");
Chicken ch = new("ニワトリ");

Bird[] birds = { c, s, ch };
foreach (var bird in birds)
{
    bird.Sing();
}
