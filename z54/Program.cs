// Задача 54: 
// Задайте двумерный массив. Напишите программу, которая 
// упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// В итоге получается вот такой массив:

// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

Console.WriteLine("Задача 54: Задайте двумерный массив. Напишите программу, " +
                  "которая упорядочит по убыванию элементы каждой строки двумерного массива.");
var numbersArray = GetNumbers("Укажите 1 число для строк," +
                              " второе количество столбцов: ", true);
if (numbersArray.Length >= 2)
{
    var setArray = RandomArray(numbersArray[0], numbersArray[1], 1);
    Print(setArray);
    Console.WriteLine();
    setArray = SortArray(setArray);
    Print(setArray);
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

int[,] SortArray(int[,] tableArray)
{
    for (int i = 0; i < tableArray.GetLength(0); i++)
    {
        var tempRow = GetArray(tableArray, i);
        Array.Sort(tempRow);
        Array.Reverse(tempRow);
        for (int j = 0; j < tableArray.GetLength(1); j++)
        {
            tableArray[i, j] = tempRow[j];
        }
    }

    return tableArray;
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

int[] GetArray(int[,] tableArray, int i)
{
    int[] tempRow = new int[tableArray.GetLength(1)];
    for (int j = 0; j < tableArray.GetLength(1); j++)
    {
        tempRow[j] = tableArray[i, j];
    }

    return tempRow;
}
