using System.Windows.Forms.DataVisualization.Charting;

namespace BSmith.Math
{
    /// <summary>
    /// A static class containing math functions.
    /// </summary>
    public static class Functions
    {
        public static double LeastCommonMultiple(long A, long B)
        {
            return new Fraction(System.Math.Abs(A * B), GreatestCommonDivisor(A, B)).Approximate();
        }

        /// <summary>
        /// Finds the greatest common divisor between the supplied numbers.
        /// </summary>
        /// <remarks>Negative numbers need to be inputted as absolute values.</remarks>
        /// <param name="A">The dividend.</param>
        /// <param name="B">The divisor.</param>
        /// <returns>Returns the greatest divisor that both numbers have in common.</returns>
        public static long GreatestCommonDivisor(long A, long B)
        {
            var quotient = 0;
            var operand = A;

            while (operand - B >= 0)
            {
                operand -= B;
                ++quotient;
            }

            var remainder = A - (quotient * B);

            return (remainder == 0) ? B : GreatestCommonDivisor(B, remainder);
        }

        /// <summary>
        /// Finds the dot product between the supplied fraction arrays.
        /// </summary>
        /// <param name="A">First fraction array.</param>
        /// <param name="B">Second fraction array.</param>
        /// <returns>Returns the dot product between two arrays of fractions.</returns>
        public static Fraction DotProduct(Fraction[] A, Fraction[] B)
        {
            var result = new Fraction(0);

            if (A.Length == B.Length)
            {
                for (var row_index = 0; row_index < A.Length; ++row_index)
                {
                    if (!result.Equals(new Fraction(0)))
                    {
                        result = Fraction.Add(result, Fraction.Multiply(A[row_index], B[row_index]), true);
                    }
                    else
                    {
                        result = Fraction.Multiply(A[row_index], B[row_index], true);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Returns the absolute value of a fraction.
        /// </summary>
        /// <param name="fraction">The fraction to find the absolute value of.</param>
        /// <returns>The absolute value of a fraction.</returns>
        public static Fraction Abs(Fraction fraction)
        {
            var result = new Fraction(fraction.Numerator, fraction.Denominator);

            result.Numerator /= (fraction.Numerator > 0) ? 1 : -1;
            result.Denominator /= (fraction.Denominator > 0) ? 1 : -1;

            return result;
        }

        public static Fraction Pow(Fraction A, int power)
        {
            var product = A;

            if (power != 0)
            {
                for (var i = 0; i < power - 1; ++i)
                {
                    product = Fraction.Multiply(product, A);
                }
            }
            else
            {
                product = new Fraction(1);
            }

            return product;
        }

        public static Fraction Min(Fraction[] fractions)
        {
            var min = new Fraction(0);

            for (var i = 0; i < fractions.Length; ++i)
            {
                min = (fractions[i].LessThan(min)) ? fractions[i] : min;
            }

            return min;
        }

        public static Fraction Max(Fraction[] fractions)
        {
            var max = new Fraction(0);

            for (var i = 0; i < fractions.Length; ++i)
            {
                max = (fractions[i].GreaterThan(max)) ? fractions[i] : max;
            }

            return max;
        }

        public static Matrix LeastSquares(DataPoint[] points, int degree)
        {
            var solution = new Matrix(1,1);

            if (points.GetLength(0) >= 2 && degree >= 1)
            {
                var X = new Matrix(points.GetLength(0), degree+1);

                // Setup X Matrix
                for (var r = 0; r < points.Length; ++r)
                {
                    for (var c = 0; c <= degree; ++c)
                    {
                        X.Data[r, c] = Functions.Pow(new Fraction((long)points[r].XValue), c);                    
                    }
                }

                var Y = new Matrix(points.GetLength(0), 1);

                // Setup Y Matrix
                for (var r = 0; r < points.Length; ++r)
                {
                    Y.Data[r, 0] = new Fraction((long)points[r].YValues[0]);
                }

                var XtY = Matrix.Multiply(Matrix.Transpose(X), Y);
                var XtX = Matrix.Inverse(Matrix.Multiply(Matrix.Transpose(X), X));
               
                solution = Matrix.Multiply(XtX, XtY);
            }

            return solution;
        }
    }
}
