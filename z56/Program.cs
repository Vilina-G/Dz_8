// Задача 56: 
// Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер 
// строки с наименьшей суммой элементов: 1 строка


Console.WriteLine("Задача 56: Задайте прямоугольный двумерный массив." +
                  "Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
var numbersArray = GetNumbers("Укажите 1 число для строк, второе количество столбцов: ", true);
if (numbersArray.Length >= 2)
{
    var setArray = RandomArray(numbersArray[0], numbersArray[1], 1);
    Print(setArray);
    Console.WriteLine();
    var sum = SumArr(setArray);
    Console.WriteLine($"Строка {sum.Item1}, содержит наименьшую сумму элементов: {sum.Item2}");
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

(int, int) SumArr(int[,] tableArray)
{
    var tempRow = new int[tableArray.GetLength(0)];
    var minRow = 0;
    var minNumber = 9999;
    for (int i = 0; i < tableArray.GetLength(0); i++)
    {
        tempRow[i] = GetArray(tableArray, i).Sum();
        if (minNumber > tempRow[i])
        {
            minRow = i + 1;
            minNumber = tempRow[i];
        }
    }

    return (minRow, minNumber);
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