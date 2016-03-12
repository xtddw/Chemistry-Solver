namespace BSmith.Math
{
    public class Point
    {
        private Fraction x_value_;
        public Fraction XValue { get { return x_value_; } set { x_value_ = value; } }

        private Fraction y_value_;
        public Fraction YValue { get { return y_value_; } set { y_value_ = value; } }

        public Point(Fraction X, Fraction Y)
        {
            XValue = X;
            YValue = Y;
        }
    }
}
