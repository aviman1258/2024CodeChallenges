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
            int[][] actual = Rotate(input);
            if (Enumerable.SequenceEqual(input.SelectMany(inner => inner), expected.SelectMany(inner => inner)))
            {
                Console.WriteLine("Rotate Pass!");
                return;
            }
            Console.WriteLine("Rotate Fail!");
        }

        private static int[][] Rotate(int[][] matrix)
        {
            int[][] rotatedMatrix = new int[matrix.Length][];
            int n = matrix.Length;

            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    rotatedMatrix[j][(n - 1) - i] = matrix[i][j];
                }
            }

            return rotatedMatrix;
        }
    }
}
