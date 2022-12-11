// Задача 58: 
// Задайте две матрицы. Напишите программу, которая 
// будет находить произведение двух матриц.

// Например, даны 2 матрицы:

// 2 4 | 3 4
// 3 2 | 3 3

// Результирующая матрица будет:

// 18 20
// 15 18

Console.WriteLine("Задача 58: Задайте две матрицы. Напишите программу," +
                  "которая будет находить произведение двух матриц.");
var numbersArray = GetNumbers("Укажите 1 число для строк, второе количество столбцов: ", true);

if (numbersArray.Length >= 2)
{
    var setArray1 = RandomArray(numbersArray[0], numbersArray[1], 1);
    var setArray2 = RandomArray(numbersArray[0], numbersArray[1], 1);
    Print(setArray1);
    Console.WriteLine("Матрица 1");
    Print(setArray2);
    Console.WriteLine("Матрица 2");
    var sum = MatrixMultiple(setArray1, setArray2);
    Print(sum);
}
else
{
    Console.WriteLine("Ошибка");
}

int[] GetNumbers(string outputText = "", bool inline = false)
{
    var arrayInts = Array.Empty<int>();
    if (inline)
        Console.Write(outputText);
    else
        Console.WriteLine(outputText);
    try
    {
        char[] separators = { ' ', ',' };
        var arrayOfEnteredText = Console.ReadLine()
            ?.Split(separators,
                    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (arrayOfEnteredText != null)
            arrayInts = Array.ConvertAll(arrayOfEnteredText, s => int.Parse(s));
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }

    return arrayInts;
}

int[,] RandomArray(int rows, int columns, int from = -9, int to = 10)
{
    var tableArray = new int[rows, columns];
    var rand = new Random();
    for (int i = 0; i < tableArray.GetLength(0); i++)
    {
        for (int j = 0; j < tableArray.GetLength(1); j++)
        {
            tableArray[i, j] = rand.Next(from, to);
        }
    }

    return tableArray;
}

void Print(int[,] generatedTable)
{
    for (int i = 0; i < generatedTable.GetLength(0); i++)
    {
        for (int j = 0; j < generatedTable.GetLength(1); j++)
        {
            Console.Write($"{String.Format("{0:0.#}", generatedTable[i, j])} ");
        }

        Console.WriteLine();
    }
}

//a11*b11 + a12 * b21
// 2*3    +   4*3
int[,] MatrixMultiple(int[,] tableArray1, int[,] tableArray2)
{
    var tableOneRowLength = tableArray1.GetLength(0);
    var tableOneColLength = tableArray1.GetLength(1);
    int[,] multipleArray = new int[tableOneRowLength, tableOneColLength];
    for (int i = 0; i < tableOneRowLength; i++)
    {
        for (int j = 0; j < tableOneColLength; j++)
        {
            int sum = 0;
            for (int k = 0; k < tableOneColLength; k++)
            {
                sum += tableArray1[i, k] * tableArray2[k, j];
            }

            multipleArray[i, j] = sum;
        }
    }

    return multipleArray;
}