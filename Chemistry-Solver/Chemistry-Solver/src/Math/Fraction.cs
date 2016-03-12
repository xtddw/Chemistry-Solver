namespace BSmith.Math
{
    /// <summary>
    /// A structure representing a fraction.
    /// </summary>
    public struct Fraction
    {
        private long numerator_;
        public long Numerator { get { return numerator_; } set { numerator_ = value; } }

        private long denominator_;
        public long Denominator { get { return denominator_; } set { denominator_ = value; } }

        /// <summary>
        /// Constructs a fraction from two integers.
        /// </summary>
        /// <param name="numerator">Integer value for the numerator.</param>
        /// <param name="denominator">Integer value for the denominator.</param>
        public Fraction(long numerator, long denominator)
        {
            numerator_ = numerator;
            denominator_ = denominator;
        }

        /// <summary>
        /// Constructs a fraction from a single integer value.
        /// </summary>
        /// <param name="numerator">Integer value for the numerator.</param>
        public Fraction(long numerator)
        {
            numerator_ = numerator;
            denominator_ = 1;
        }

        /// <summary>
        /// Simplifys a fraction.
        /// </summary>
        /// <param name="fraction">The fraction to be simplified.</param>
        /// <returns>The simplified fraction.</returns>
        public static Fraction Simplify(Fraction fraction) 
        {
            if(fraction.Numerator == 0
                || fraction.Denominator == 0)
            {
                fraction.Numerator = 0;
                fraction.Denominator = 0;
            }
            else
            {
                if (fraction.Denominator != 1)
                {
                    var GCD = Functions.GreatestCommonDivisor(System.Math.Abs(fraction.Numerator), System.Math.Abs(fraction.Denominator));
                    GCD *= (fraction.Numerator < 0 && fraction.Denominator < 0) ? -1 : 1;

                    fraction.Numerator /= GCD;
                    fraction.Denominator /= GCD;

                    if (fraction.Denominator < 0 && fraction.Numerator > 0)
                    {
                        fraction.Numerator /= -1;
                        fraction.Denominator /= -1;
                    }
                }
            }

            return fraction;
        }

        /// <summary>
        /// Finds the sum of two fractions.
        /// </summary>
        /// <param name="first">First fraction.</param>
        /// <param name="second">Second fraction.</param>
        /// <param name="simplified">Indicates if the operation should return a simplified fraction or not.</param>
        /// <returns>The sum of two fractions.</returns>
        public static Fraction Add(Fraction first, Fraction second, bool simplified = false)
        {
            var sum = new Fraction(0);

            if (first.Equals(new Fraction(0))
                && !second.Equals(new Fraction(0)))
            {
                sum = second;
            }
            else if (second.Equals(new Fraction(0))
                && !first.Equals(new Fraction(0)))
            {
                sum = first;
            }
            else
            {
                sum.Numerator = (first.Numerator * second.Denominator) + (second.Numerator * first.Denominator);
                sum.Denominator = first.Denominator*second.Denominator;
            }

            return (simplified) ? Fraction.Simplify(sum) : sum;
        }

        /// <summary>
        /// Finds the difference between two fractions.
        /// </summary>
        /// <param name="first">First fraction.</param>
        /// <param name="second">Second fraction.</param>
        /// <param name="simplified">Indicates if the operation should return a simplified fraction or not.</param>
        /// <returns>The difference of two fractions.</returns>
        public static Fraction Subtract(Fraction first, Fraction second, bool simplified = false)
        {
            var difference = new Fraction(0);

            if (first.Equals(new Fraction(0))
                && !second.Equals(new Fraction(0)))
            {
                difference = Fraction.Multiply(second, -1);
            }
            else if (second.Equals(new Fraction(0))
                && !first.Equals(new Fraction(0)))
            {
                difference = first;
            }
            else
            {
                difference.Numerator = (first.Numerator * second.Denominator) - (second.Numerator * first.Denominator);
                difference.Denominator = first.Denominator * second.Denominator;
            }
            return (simplified) ? Fraction.Simplify(difference) : difference;
        }

        /// <summary>
        /// Finds the product of two fractions.
        /// </summary>
        /// <param name="first">First fraction.</param>
        /// <param name="second">Second fraction.</param>
        /// <param name="simplified">Indicates if the operation should return a simplified fraction or not.</param>
        /// <returns>The product of two fractions.</returns>
        public static Fraction Multiply(Fraction first, Fraction second, bool simplified = false)
        {
            first.Numerator *= second.Numerator;
            first.Denominator *= second.Denominator;

            return (simplified) ? Fraction.Simplify(first) : first;
        }

        /// <summary>
        /// Finds the product of a fraction and a scalar.
        /// </summary>
        /// <param name="first">Fraction to be multiply a scalar by.</param>
        /// <param name="second">Scalar to multiply a fraction by.</param>
        /// <param name="simplified">Indicates if the operation should return a simplified fraction or not.</param>
        /// <returns>The product of a fraction and a scalar.</returns>
        public static Fraction Multiply(Fraction first, int second, bool simplified = false)
        {
            first.Numerator *= second;

            return (simplified) ? Fraction.Simplify(first) : first;
        }

        /// <summary>
        /// Finds the quotient of two fractions.
        /// </summary>
        /// <param name="first">The dividend.</param>
        /// <param name="second">The divisor.</param>
        /// <param name="simplified">Indicates if the operation should return a simplifed fraction or not.</param>
        /// <returns>The quotient of two fractions.</returns>
        public static Fraction Divide(Fraction first, Fraction second, bool simplified = false)
        {
            first.Numerator *= second.Denominator;
            first.Denominator *= second.Numerator;

            return (simplified) ? Fraction.Simplify(first) : first;
        }

        /// <summary>
        /// Returns the exact value of the fraction.
        /// </summary>
        /// <returns>The exact value of the fraction.</returns>
        public Fraction Exact()
        {
            return this;
        }
        
        /// <summary>
        /// Returns the approximate value of the fraction.
        /// </summary>
        /// <returns>The approximate value of the fraction.</returns>
        public double Approximate()
        {
            return (denominator_ != 0) ? System.Math.Round((double)(numerator_) / (double)(denominator_), 5) : 0;
        }

        /// <summary>
        /// Checks for equality between this, and another fraction.
        /// </summary>
        /// <param name="fraction">Fraction to compare against.</param>
        /// <returns>A boolean value indicating equality.</returns>
        public bool Equals(Fraction fraction)
        {
            return (this.Approximate() == fraction.Approximate()) ? true : false;
        }

        /// <summary>
        /// Returns a boolean value indicating whether or not this fraction is greater than another.
        /// </summary>
        /// <param name="fraction">Fraction to compare against.</param>
        /// <returns>A boolean value indicating if this fraction is greater than another.</returns>
        public bool GreaterThan(Fraction fraction)
        {
            return (this.Approximate() > fraction.Approximate()) ? true : false;
        }

        /// <summary>
        /// Returns a boolean value indicating whether or not this fraction is less than another.
        /// </summary>
        /// <param name="fraction">Fraction to compare against.</param>
        /// <returns>A boolean value indicating if this fraction is less than another.</returns>
        public bool LessThan(Fraction fraction)
        {
            return (this.Approximate() < fraction.Approximate()) ? true : false;
        }

        /// <summary>
        /// Returns the fraction as a string.
        /// </summary>
        /// <param name="exact">A boolean value indicating if the function should be displayed as an exact or approximate value.</param>
        /// <returns>The fraction as a string.</returns>
        public override string ToString()
        {
            return string.Format("{0} / {1}", Numerator, Denominator); //string.Format("{0}", Approximate());
        }
    }
}
