using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FunWithMatrices
{
    static void Main(string[] args)
    {
        double startNumber = double.Parse(Console.ReadLine());
        double step = double.Parse(Console.ReadLine());
        string command = "";
        char separator = ' ';
        List<string[]> commands = new List<string[]>();

        again:
        while (command.ToLower() != "game over!")
        {
            command = Console.ReadLine();

            if (command.ToLower() == "game over!")
            {
                break;
            }

            string[] commandArr = command.Split(separator);

            if (int.Parse(commandArr[0]) < 0 || int.Parse(commandArr[0]) > 3 || int.Parse(commandArr[1]) < 0 || int.Parse(commandArr[1]) > 3)
            {
                goto again;
            }
            else
            {
                commands.Add(commandArr);
            }
            //command = "";
        }

        //creating and initializating the matrix
        double[,] matrix = new double[4,4];
        matrix[0, 0] = startNumber;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i > 0)
            {
                matrix[i, 0] += matrix[i - 1, matrix.GetLength(1) - 1] + step;
            }
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] += matrix[i, j - 1] + step;
            }
        }

        /*
        Console.WriteLine();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
        */

        for (int i = 0; i < commands.Count; i++)
        {
            string[] commandArr = commands[i];

            if (commandArr[2] == "multiply")
            {
                matrix[int.Parse(commandArr[0]), int.Parse(commandArr[1])] *= double.Parse(commandArr[3]);
            }
            else if (commandArr[2] == "sum")
            {
                matrix[int.Parse(commandArr[0]), int.Parse(commandArr[1])] += double.Parse(commandArr[3]);
            }
            else if (commandArr[2] == "power")
            {
                matrix[int.Parse(commandArr[0]), int.Parse(commandArr[1])] = Math.Pow(matrix[int.Parse(commandArr[0]), int.Parse(commandArr[1])], double.Parse(commandArr[3]));
            }
        }

        /*
        Console.WriteLine();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }*/

        //calculating the best row
        double bestRowSum = double.MinValue;
        int bestRow = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            double sum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[i, j];
            }

            if (sum > bestRowSum)
            {
                bestRowSum = sum;
                bestRow = i;
            }
        }

        //calculating the best column
        double bestColumnSum = double.MinValue;
        int bestColumn = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            double sum = 0;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                sum += matrix[j, i];
            }

            if (sum > bestColumnSum)
            {
                bestColumnSum = sum;
                bestColumn = i;
            }
        }

        //calculating the diagonals
        double leftDiagonalSum = 0.0;
        double rightDiagonalSum = 0.0;
        int matrixRowNumber = matrix.GetLength(0) - 1;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            leftDiagonalSum += matrix[i, i];
            rightDiagonalSum += matrix[matrixRowNumber, i];
            matrixRowNumber -- ;
        }

        // Console.WriteLine("{0}\n{1}\n{2}\n{3}", bestRowSum, bestColumnSum, leftDiagonalSum, rightDiagonalSum);

        double bestSum = Math.Max(bestRowSum, Math.Max(bestColumnSum, Math.Max(leftDiagonalSum, rightDiagonalSum)));

        if (bestSum == bestRowSum)
        {
            Console.WriteLine("ROW[{0}] = {1:F2}", bestRow, bestRowSum);
        }
        else if (bestSum == bestColumnSum)
        {
            Console.WriteLine("COLUMN[{0}] = {1:F2}", bestColumn, bestColumnSum);
        }
        else if (bestSum == leftDiagonalSum)
        {
            Console.WriteLine("LEFT-DIAGONAL = {0:F2}", leftDiagonalSum);
        }
        else
        {
            Console.WriteLine("RIGHT-DIAGONAL = {0:F2}", rightDiagonalSum);
        }
    }
}
