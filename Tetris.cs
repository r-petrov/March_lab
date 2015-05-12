using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Tetris
{
    static void Main(string[] args)
    {
        //input the inputArr of tetris game field
        inputMeasures:
        string[] input = Console.ReadLine().Split(' ');

        if ((int.Parse(input[0]) < 2 || int.Parse(input[0]) > 100) || (int.Parse(input[1]) < 2 || int.Parse(input[1]) > 100))
        {
            goto inputMeasures;
        }

        //fill the tetris game field with "-" and "o"
        int row = int.Parse(input[0]);
        int col = int.Parse(input[1]);
        string inputLine = "";

        char[,] gameField = new char[row, col];

        for (int i = 0; i < row; i++)
        {
            inputLine = Console.ReadLine();
            for (int j = 0; j < col; j++)
            {
                gameField[i, j] = inputLine[j];
            }
        }

        Console.WriteLine("I:{0}, L:{1}, J:{2}, O:{3}, Z:{4}, S:{5}, T:{6}", 
            CountI(gameField), CountL(gameField), CountJ(gameField), CountO(gameField), CountZ(gameField), CountS(gameField), CountT(gameField));
    }
    static int CountI(char[,] matrix)
    {
        int count = 0;

        for (int i = 0; i < matrix.GetLength(0) - 3; i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 'o' && matrix[i + 1, j] == 'o' && matrix[i + 2, j] == 'o' && matrix[i + 3, j] == 'o')
                {
                    count++;
                }
            }
        }
        return count;
    }

    static int CountL(char[,] matrix)
    {
        int count = 0;

        for (int i = 0; i < matrix.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[i, j] == 'o' && matrix[i + 1, j] == 'o' && matrix[i + 2, j] == 'o' && matrix[i + 2, j + 1] == 'o')
                {
                    count++;
                }
            }
        }
        return count;
    }

    static int CountJ(char[,] matrix)
    {
        int count = 0;

        for (int i = 0; i < matrix.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[i, j + 1] == 'o' && matrix[i + 1, j + 1] == 'o' && matrix[i + 2, j] == 'o' && matrix[i + 2, j + 1] == 'o')
                {
                    count++;
                }
            }
        }
        return count;
    }

    static int CountO(char[,] matrix)
    {
        int count = 0;

        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[i, j] == 'o' && matrix[i, j + 1] == 'o' && matrix[i + 1, j] == 'o' && matrix[i + 1, j + 1] == 'o')
                {
                    count++;
                }
            }
        }
        return count;
    }

    static int CountZ(char[,] matrix)
    {
        int count = 0;

        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 2; j++)
            {
                if (matrix[i, j] == 'o' && matrix[i, j + 1] == 'o' && matrix[i + 1, j + 1] == 'o' && matrix[i + 1, j + 2] == 'o')
                {
                    count++;
                }
            }
        }
        return count;
    }
    static int CountS(char[,] matrix)
    {
        int count = 0;

        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 2; j++)
            {
                if (matrix[i, j + 1] == 'o' && matrix[i, j + 2] == 'o' && matrix[i + 1, j] == 'o' && matrix[i + 1, j + 1] == 'o')
                {
                    count++;
                }
            }
        }
        return count;
    }

    static int CountT(char[,] matrix)
    {
        int count = 0;

        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 2; j++)
            {
                if (matrix[i, j] == 'o' && matrix[i, j + 1] == 'o' && matrix[i, j + 2] == 'o' && matrix[i + 1, j + 1] == 'o')
                {
                    count++;
                }
            }
        }
        return count;
    }
}
