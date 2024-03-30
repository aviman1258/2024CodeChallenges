namespace _2024LeetCode
{
    internal class RotateMatrixNinetyDegrees
    {
        public static void TestRotate()
        {
            TestRotate(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } }
            , new int[][] { new int[] { 7, 4, 1 }, new int[] { 8, 5, 2 }, new int[] { 9, 6, 3 } });

            // 1 2 3       7 4 1
            // 4 5 6  -->  8 5 2
            // 7 8 9       9 6 3

            TestRotate(new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 9, 10, 11, 12 }, new int[] { 13, 14, 15, 16 } },
                new int[][] { new int[] { 13, 9, 5, 1 }, new int[] { 14, 10, 6, 2 }, new int[] { 15, 11, 7, 3 }, new int[] { 16, 12, 8, 4 } });

            //  1  2  3  4       13  9  5  1
            //  5  6  7  8  -->  14 10  6  2
            //  9 10 11 12       15 11  7  3
            // 13 14 15 16       16 12  8  4
        }

        private static void TestRotate(int[][] input, int[][] expected)
        {
            int[][] actual = RotateInPlace(input);

            bool pass = true;

            for (int q = 0; q < input.Length; q++)
            {
                for (int w = 0; w < input[q].Length; w++)
                {
                    if (actual[q][w] != expected[q][w])
                        pass = false;
                }
            }

            if (pass)
            {
                Console.WriteLine("Rotate Pass!");
            }
            else
            {
                Console.WriteLine("Rotate Fail!");
            }

            for (int i = 0; i < expected.Length; i++)
            {
                // Label for expected array
                Console.Write("expected: ");
                for (int j = 0; j < expected[i].Length; j++)
                {
                    Console.Write(expected[i][j].ToString().PadLeft(4) + " ");
                }
                Console.Write(" : ");

                // Label for input array
                Console.Write("input: ");
                for (int j = 0; j < input[i].Length; j++)
                {
                    Console.Write(input[i][j].ToString().PadLeft(4) + " ");
                }
                Console.Write(" --> ");

                // Label for result array
                Console.Write("actual: ");
                for (int j = 0; j < actual[i].Length; j++)
                {
                    Console.Write(actual[i][j].ToString().PadLeft(4) + " ");
                }
                Console.WriteLine(); // Move to the next line after each row
            }
        }

        /// <summary>
        /// Rotate n x n matrix 90 degrees clockwise. Time complexity O(n^2). Space compexity O(n^2)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static int[][] Rotate(int[][] matrix)
        {
            int[][] rotatedMatrix = new int[matrix.Length][];
            int n = matrix.Length;

            for (int a = 0; a < n; a++)
            {
                rotatedMatrix[a] = new int[n];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    rotatedMatrix[j][(n - 1) - i] = matrix[i][j];
                }
            }

            return rotatedMatrix;
        }

        /// <summary>
        /// Rotate n x n matrix 90 degrees clockwise. Time complexity O(n^4). Space compexity O(n)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static int[][] RotateInPlace(int[][] matrix)
        {
            int n = matrix.Length;

            for(int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    matrix[i][j] = matrix[i][j] + matrix[j][i];
                    matrix[j][i] = matrix[i][j] - matrix[j][i];
                    matrix[i][j] = matrix[i][j] - matrix[j][i];
                }
            }

            for (int a = 0; a < n; a++)
            {
                for(int b = 0; b < n/2; b++)
                {
                    matrix[a][b] = matrix[a][b] + matrix[a][n-b-1];
                    matrix[a][n-b-1] = matrix[a][b] - matrix[a][n-b-1];
                    matrix[a][b] = matrix[a][b] - matrix[a][n-b-1];
                }
            }

            return matrix;
        }
    }
}
