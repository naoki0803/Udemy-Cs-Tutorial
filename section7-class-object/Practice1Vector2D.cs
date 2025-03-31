namespace section7_class_object
{
    public class Practice1Vector2D
    {
        private double x, y;

        public Practice1Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X
        {
            set; get;
        }
        public double Y
        {
            set; get;
        }

        public void Add(Practice1Vector2D v)
        {
            X += v.X;
            Y += v.Y;
        }
        public void Sub(Practice1Vector2D v)
        {
            X -= v.X;
            Y -= v.Y;
        }
        public void Mul(double k)
        {
            X *= k;
            Y *= k;
        }
        public double DotProduct(Practice1Vector2D v)
        {
            return X * v.X + Y * v.Y;
        }
    }

}