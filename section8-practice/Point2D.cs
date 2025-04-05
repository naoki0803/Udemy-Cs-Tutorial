namespace section8_practice;

public class Point2D : Vector2D
{
    public Point2D() : base(0, 0)
    {
    }
    public Point2D(double x, double y) : base(x, y)
    {
    }
    public Point2D(Point2D p) : base(p)
    {
    }
    public double Distance(Point2D? p)
    {
        if (p == null) return double.NaN; // nullの場合はNaNを返す

        double x = X - p.X;
        double y = Y - p.Y;
        return Math.Sqrt(x * x + y * y);

    }
    // objectクラスのEqualsメソッドをオーバーライド
    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not Point2D)
            return false;

        Point2D p = (Point2D)obj; // objをPoint2D型にキャスト
        return Distance(p) < 0.01 ? true : false; // 誤差を考慮して、距離が0.01以下ならtrue
    }

    // Equals()をオーバーライドする場合はGetHashCode()もオーバーライドする必要がある
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    /*  objectクラスのToStringメソッドをオーバーライド
        ToStringメソッドをオーバーライドする理由：
        1. デフォルトのToString()は型名のみを返すため、座標の情報が表示されない
        2. オーバーライドすることで、Point2Dオブジェクトの座標を"(x, y)"形式で表示できる
        3. これにより、デバッグやログ出力時に座標の情報を分かりやすく確認できる
    */
    public override string ToString()
    {
        string s = $"({X}, {Y})";
        return s;
    }
}
