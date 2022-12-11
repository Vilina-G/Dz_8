// Задача 62.
// Напишите программу, которая заполнит спирально массив 4 на 4. 
// Например, на выходе получается вот такой массив:

// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

Console.WriteLine("Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.");

var numbersArray = GetNumbers("Укажите 1 число для строк от 4, второе количество столбцов от 4: ", true);

if (numbersArray.Length >= 2 && numbersArray[0] >= 4 && numbersArray[1] >= 4)
{
    var spiralArray = Spiral(numbersArray);
    Print(spiralArray);
}

string[,] Spiral(int[] arrRowCol)
{
    string[,] spiralArray = new string[arrRowCol[0], arrRowCol[1]];
    var initialArray = LinearArray(spiralArray.GetLength(0) * spiralArray.GetLength(1));
    int x = 0, y = 0, xMax = spiralArray.GetLength(1) - 1, yMax = spiralArray.GetLength(0) - 1, indexInitialArray = 0;
    string direction = "right";
    for (int i = 0; i < initialArray.Length; i++)
    {
        if (spiralArray[y, x] == null)
        {
            spiralArray[y, x] = initialArray[indexInitialArray];
            indexInitialArray++;
            (direction, x, y) = CheckAction(spiralArray, direction, x, y, xMax, yMax);
        }
    }

    return spiralArray;
}

string[] LinearArray(int lengthArr)
{
    var strArr = new string[lengthArr];
    for (int i = 1; i <= lengthArr; i++)
    {
        strArr[i - 1] = (i < 10 ? "0" : "") + i.ToString();
    }
    return strArr;
}

static (string, int, int) CheckAction(string[,] spiralArray, string direction, int x, int y, int xMax, int yMax)
{
    if (direction == "right")
    {
        if (spiralArray[y, x + 1] == null)
            x += 1;
        else
        {
            direction = "down";
            y += 1;
        }
        if (x == xMax)
            direction = "down";
    }
    else if (direction == "down")
    {
        if (spiralArray[y + 1, x] == null)
            y += 1;
        else
        {
            direction = "left";
            x -= 1;
        }
        if (y == yMax)
            direction = "left";
    }
    else if (direction == "left")
    {
        if (spiralArray[y, x - 1] == null)
            x -= 1;
        else
        {
            direction = "up";
            y -= 1;
        }
        if (x == 0)
            direction = "up";
    }
    else if (direction == "up")
    {
        if (spiralArray[y - 1, x] == null)
            y -= 1;
        else
        {
            direction = "right";
            x += 1;
        }
    }
    return (direction, x, y);
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

void Print(string[,] generatedTable)// string
{
    for (int i = 0; i < generatedTable.GetLength(0); i++)
    {
        for (int j = 0; j < generatedTable.GetLength(1); j++)
        {
            Console.Write($"{generatedTable[i, j]} ");
        }

        Console.WriteLine();
    }
}