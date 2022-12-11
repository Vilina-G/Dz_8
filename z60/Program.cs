//  Задача 60. 
//  ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
//  Напишите программу, которая будет построчно выводить массив, 
//  добавляя индексы каждого элемента.

// Массив размером 2 x 2 x 2

// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

Console.WriteLine("Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел." +
                  "Напишите программу, которая будет построчно выводить массив,");
var numbersArray = GetNumbers("Укажите 3 числа для генерации трёхмерного массива: ", true);
if (numbersArray.Length >= 3)
{
    var setArray = GenTripleArr(numbersArray);
    PrintTriple(setArray);
    PrintFormatedTriple(setArray);
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

int[,,] GenTripleArr(int[] arrayNumbers, int from = 9, int to = 100)
{
    var tableArray = new int[arrayNumbers[0], arrayNumbers[1], arrayNumbers[2]];
    var rand = new Random();
    for (int i = 0; i < tableArray.GetLength(0); i++)
    {
        for (int j = 0; j < tableArray.GetLength(1); j++)
        {
            for (int k = 0; k < tableArray.GetLength(2); k++)
            {
                tableArray[i, j, k] = rand.Next(from, to);
            }
        }
    }

    return tableArray;
}

void PrintTriple(int[,,] table)
{
    for (int i = 0; i < table.GetLength(0); i++)
    {
        for (int j = 0; j < table.GetLength(1); j++)
        {
            for (int k = 0; k < table.GetLength(2); k++)
            {
                Console.Write($"{String.Format("{0:0.#}", table[i, j, k])} ");
            }
        }

        Console.WriteLine();
    }
}

void PrintFormatedTriple(int[,,] table)
{
    for (int z = 0; z < table.GetLength(2); z++)
    {
        for (int i = 0; i < table.GetLength(0); i++)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                Console.Write($"{table[i, j, z]} ({i}, {j}, {z}) ");
            }

            Console.WriteLine();
        }
    }
}