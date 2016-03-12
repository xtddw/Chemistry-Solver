namespace BSmith.Math
{
    /// <summary>
    /// A structure representing a matrix.
    /// </summary>
    public class Matrix
    {
        private Fraction[,] data_;
        public Fraction[,] Data { get { return data_; } set { data_ = value; } }

        private bool exact_values_;
        public bool ExactValues { get { return exact_values_; } set { exact_values_ = value; } }

        /// <summary>
        /// Constructs an empty matrix with the given dimensions.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="columns">The number of columns in the matrix.</param>
        public Matrix(int rows, int columns)
        {
            data_ = new Fraction[rows, columns];
        }

        /// <summary>
        /// Constructs a matrix with the given data.
        /// </summary>
        /// <param name="data">A two-dimensional array of fractions.</param>
        public Matrix(Fraction[,] data)
        {
            data_ = data;
        }

        /// <summary>
        /// Returns an identity matrix of the specified size.
        /// </summary>
        /// <remarks>The created identity matrix will be a square matrix, so the specified size is both the number of rows and columns.</remarks>
        /// <param name="size">The number of rows in the identity matrix.</param>
        /// <returns>An identity matrix of the specified size.</returns>
        public static Matrix Identity(int size)
        {
            var output = new Matrix(size, size);

            for (var i = 0; i < size; ++i)
            {
                output.Data[i, i] = new Fraction(1, 1);
            }

            return output;
        }

        /// <summary>
        /// Multiplies two matricies together.
        /// </summary>
        /// <param name="A">The first matrix.</param>
        /// <param name="B">The second matrix.</param>
        /// <returns>The product of the provided matricies.</returns>
        public static Matrix Multiply(Matrix A, Matrix B)
        {
            var result = new Matrix(A.Data.GetLength(0), B.Data.GetLength(1));

            if (A.Data.GetLength(1) == B.Data.GetLength(0))
            {
                for (var row_index = 0; row_index < result.Data.GetLength(0); ++row_index)
                {
                    for (var column_index = 0; column_index < result.Data.GetLength(1); ++column_index)
                    {
                        result.Data[row_index, column_index] = Functions.DotProduct(Matrix.GetRow(A, row_index), Matrix.GetColumn(B, column_index));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets an array of fractional values from the specified row.
        /// </summary>
        /// <param name="matrix">The matrix to get the values from.</param>
        /// <param name="row">The index of the desired row.</param>
        /// <returns>An array of fractional values.</returns>
        public static Fraction[] GetRow(Matrix matrix, int row)
        {
            var result = new Fraction[0];

            if(matrix.Data.Rank == 2
                && row < matrix.Data.GetLength(0))
            {
                result = new Fraction[matrix.Data.GetLength(1)];

                for (var column_index = 0; column_index < matrix.Data.GetLength(1); ++column_index)
                {
                    result[column_index] = matrix.Data[row, column_index];
                }
            }

            return result;
        }

        /// <summary>
        /// Gets an array of fractional value sfrom the specified column.
        /// </summary>
        /// <param name="matrix">The matrix to get the values from.</param>
        /// <param name="column">The index of the desired column.</param>
        /// <returns>An array of fractional values.</returns>
        public static Fraction[] GetColumn(Matrix matrix, int column)
        {
            var result = new Fraction[0];

            if (matrix.Data.Rank == 2
                && column < matrix.Data.GetLength(1))
            {
                result = new Fraction[matrix.Data.GetLength(0)];

                for (var row_index = 0; row_index < matrix.Data.GetLength(0); ++row_index)
                {
                    result[row_index] = matrix.Data[row_index, column];
                }
            }

            return result;
        }

        /// <summary>
        /// Swaps two rows inside the parent matrix.
        /// </summary>
        /// <param name="first_row">The first row.</param>
        /// <param name="second_row">The second row.</param>
        private void SwapRows(int first_row, int second_row)
        {
            if(first_row < data_.GetLength(0)
                && second_row < data_.GetLength(0))
            {
                for (var i = 0; i < data_.GetLength(1); ++i)
                {
                    var pivot_value = data_[first_row, i];
                    var row_value = data_[second_row, i];
                    data_[first_row, i] = row_value;
                    data_[second_row, i] = pivot_value;
                }
            }
        }

        /// <summary>
        /// Subtracts the specified row from the scalar product of the pivot row.
        /// </summary>
        /// <param name="row_index">The row index of the row operand.</param>
        /// <param name="col_index">The column index of the row operands leading coefficient.</param>
        /// <param name="pivot_row_index">The row index of the pivot row.</param>
        private void SubtractRow(int row_index, int col_index, int pivot_row_index)
        {
            if(row_index < data_.GetLength(0)
                && pivot_row_index < data_.GetLength(0))
            {
                var scalar = Fraction.Divide(data_[row_index, col_index], data_[pivot_row_index, col_index], true);

                for (var i = pivot_row_index; i < data_.GetLength(1); ++i)
                {
                    var cell_value = data_[row_index, i];
                    var pivot_cell_value = data_[pivot_row_index, i];
                    var result = Fraction.Subtract(cell_value, Fraction.Multiply(pivot_cell_value, scalar), true);

                    data_[row_index, i] = result;
                }
            }
        }

        /// <summary>
        /// Divides the entire row by leading coefficient.
        /// </summary>
        /// <param name="row_index">The row operand.</param>
        /// <param name="pivot_index">The pivot row.</param>
        private void NormalizeRow(int row_index, int pivot_index)
        {
            if (row_index < data_.GetLength(0)
                && pivot_index < data_.GetLength(1))
            {
                var scalar = data_[row_index, pivot_index];

                for (var i = pivot_index; i < data_.GetLength(1); ++i)
                {
                    data_[row_index, i] = Fraction.Divide(data_[row_index, i], scalar, true);
                }
            }
        }

        /// <summary>
        /// Finds the transpose of a Matrix
        /// </summary>
        /// <param name="A">The Matrix to find a transpose of.</param>
        /// <returns>The transpose of Matrix A</returns>
        public static Matrix Transpose(Matrix A)
        {
            var output = new Matrix(A.Data.GetLength(1), A.Data.GetLength(0));
 
            for (var i = 0; i < A.Data.GetLength(0); ++i)
            {
                var row = Matrix.GetRow(A, i);

                for (var j = 0; j < row.GetLength(0); j++)
                {
                    output.Data[j, i] = row[j];
                }
            }

            return output;
        }

        /// <summary>
        /// Augments Matrix B onto Matrix A.
        /// </summary>
        /// <param name="A">Matrix vectors will be added too.</param>
        /// <param name="B">Matrix supplying the vectors.</param>
        /// <returns>An augmented matrix, containing the data from both A and B.</returns>
        public static Matrix Augment(Matrix A, Matrix B)
        {
            var output = new Matrix(0, 0);

            if (A.Data.GetLength(0) == B.Data.GetLength(0))
            {
                output = new Matrix(A.Data.GetLength(0), A.Data.GetLength(1) + B.Data.GetLength(1));

                for (int i = 0; i < output.Data.GetLength(0); ++i)
                {
                    for (int j = 0; j < output.Data.GetLength(1); ++j)
                    {
                        output.Data[i, j] = (j < A.Data.GetLength(1)) ? A.Data[i, j] : B.Data[i, j - A.Data.GetLength(1)];
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// Creates a submatrix containing the data from the supplied matrix, within the boundaries given.
        /// </summary>
        /// <param name="A">Data containing matrix to extract information from.</param>
        /// <param name="row_range">The range of rows the submatrix encompasses.</param>
        /// <param name="column_range">The range of columns the submatrix encompasses.</param>
        /// <returns>A submatrix with the data from the boundaries specified.</returns>
        public static Matrix Submatrix(Matrix A, int[] row_range, int[] column_range)
        {
            var row_lower_limit = System.Math.Min(row_range[0], row_range[1]);
            var row_upper_limit = System.Math.Max(row_range[0], row_range[1]);
            var col_lower_limit = System.Math.Min(column_range[0], column_range[1]);
            var col_upper_limit = System.Math.Max(column_range[0], column_range[1]);

            var sub_matrix = new Matrix(0, 0);

            if (row_range.Length == 2 && column_range.Length == 2
                && row_lower_limit >= 0 && row_upper_limit <= A.Data.GetLength(0)
                && col_lower_limit >= 0 && col_upper_limit <= A.Data.GetLength(1)
                && row_upper_limit < A.Data.GetLength(0) && col_upper_limit < A.Data.GetLength(1))
            {
                sub_matrix = new Matrix(row_upper_limit - row_lower_limit + 1, col_upper_limit - col_lower_limit + 1);

                for (var r = row_lower_limit; r <= row_upper_limit; ++r)
                {
                    for (var c = col_lower_limit; c <= col_upper_limit; ++c)
                    {
                        sub_matrix.Data[r - row_lower_limit, c - col_lower_limit] = A.Data[r, c];
                    }
                }
            }

            return sub_matrix;
        }

        /// <summary>
        /// Finds the inverse of a Matrix.
        /// </summary>
        /// <param name="A">The Matrix to find the inverse of.</param>
        /// <returns>The inverted matrix. Techincal failure returns the supplied matrix.</returns>
        public static Matrix Inverse(Matrix A)
        {
            var output = new Matrix(A.Data);

            // A is an nxn matrix.
            if (A.Data.GetLength(0) == A.Data.GetLength(1))
            {
                var aug_matrix = Matrix.Augment(A, Matrix.Identity(A.Data.GetLength(0)));
                aug_matrix = Matrix.Rref(aug_matrix);

                output = Matrix.Submatrix(aug_matrix, new int [] { 0, aug_matrix.Data.GetLength(0) - 1 }, new int [] { A.Data.GetLength(1), aug_matrix.Data.GetLength(1) - 1 });
            }

            return output;
        }

        /// <summary>
        /// Puts the specified matrix into reduced row echelon form.
        /// </summary>
        /// <param name="matrix">The matrix to put into reduced row echelon form.</param>
        /// <returns>A matrix in reduced row echelon form.</returns>
        public static Matrix Rref(Matrix matrix)
        {
            var u_matrix = new Matrix(matrix.Data);
   
            // Reduce lower triangle
            for (var column_index = 0; column_index < u_matrix.Data.GetLength(0); ++column_index)
            {        
                var pivot_row_index = column_index;
                var pivot_value = new Fraction(0);
                var pivot_found = false;

                // Find Pivot in current row.
                for (var row_index = column_index; row_index < u_matrix.Data.GetLength(0) && !pivot_found; ++row_index)
                {
                    if(!u_matrix.Data[row_index, column_index].Equals(new Fraction(0)))
                    {
                        pivot_value = u_matrix.Data[row_index, column_index];
                        pivot_row_index = row_index;
                        pivot_found = true;
                    }                     
                }

                // swap pivot if necessary
                if (pivot_found)
                {
                    u_matrix.SwapRows(pivot_row_index, column_index);
                    pivot_row_index = column_index;
                }

                // if a pivot was found for the column
                if (!pivot_value.Equals(new Fraction(0)))
                {
                    // Reduce the pivot coefficient to 1
                    if (!u_matrix.Data[pivot_row_index, column_index].Equals(new Fraction(1)))
                    {
                        u_matrix.NormalizeRow(pivot_row_index, pivot_row_index);
                    }

                    // Row operations, Set L matrix too
                    for (var row_index = pivot_row_index + 1; row_index < u_matrix.Data.GetLength(0); ++row_index)
                    {
                        // If value under pivot is not 0
                        if(!u_matrix.Data[row_index, column_index].Equals(new Fraction(0)))
                        {                       
                            u_matrix.SubtractRow(row_index, column_index, pivot_row_index);
                        }
                    }
                }
            }

            // Reduce upper triangle
            for (var column_index = u_matrix.Data.GetLength(1) - 1; column_index > 0; --column_index) 
            { 
                // Find Pivot

                var pivot_row_index = 0;
                var pivot_value = new Fraction(0);

                for (var row_index = u_matrix.Data.GetLength(0)-1; row_index >= 0; --row_index)
                {
                    if(u_matrix.Data[row_index, column_index].Equals(new Fraction(1))
                    && u_matrix.Data[row_index, column_index-1].Equals(new Fraction(0)))
                    {
                        pivot_value = u_matrix.Data[row_index, column_index];
                        pivot_row_index = row_index;
                    }
                }
                
                // Make values zero above pivot
                if (!pivot_value.Equals(new Fraction(0)))
                {
                    for (var row_index = pivot_row_index-1; row_index >= 0; --row_index)
                    {
                        if (!u_matrix.Data[row_index, column_index].Equals(new Fraction(0)))
                        {
                            u_matrix.SubtractRow(row_index, column_index, pivot_row_index);
                        }
                    }
                }
            }

            return u_matrix;
        }

        /// <summary>
        /// Casts the matrix into a formatted string.
        /// </summary>
        /// <returns>The formatted string.</returns>
        public override string ToString()
        {
            var result = string.Empty;

            for (var row_index = 0; row_index < data_.GetLength(0); ++row_index)
            {
                result += "[";

                for (var column_index = 0; column_index < data_.GetLength(1); ++column_index)
                {
                    result += (exact_values_ == true) ? data_[row_index, column_index].Approximate().ToString() : data_[row_index, column_index].ToString();
                    result += (column_index < data_.GetLength(1) - 1) ? ", " : string.Empty;
                }

                result += "]\n";
            }

            return result;
        }
    }
}
