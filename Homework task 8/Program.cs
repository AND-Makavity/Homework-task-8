/*Урок 8. Как не нужно писать код. Часть 2
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы 
каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2*/
Console.WriteLine("\nПрограмма упорядочивает по убыванию элементы каждой строки:");
int[,] array = new int[4, 4];

void FillArray(int[,] _array, int min = 0, int max = 10)
{
    Console.WriteLine();
    for (int i = 0; i < _array.GetLength(0); i++)
    {
        for (int j = 0; j < _array.GetLength(1); j++)
        {
            _array[i, j] = new Random().Next(min, max);
            Console.Write($"{_array[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

void PrintArray(int[,] _array)
{
    Console.WriteLine();
    for (int i = 0; i < _array.GetLength(0); i++)
    {
        for (int j = 0; j < _array.GetLength(1); j++)
        {
            Console.Write($"{_array[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

void SortString(int[,] _array, int row)
{
    int temp;
    for (int k = 0; k < _array.GetLength(1) - 1; k++)
        for (int i = 1; i < _array.GetLength(1); i++)
        {
            if (_array[row, i] < _array[row, i - 1])
            {
                temp = _array[row, i - 1];
                _array[row, i - 1] = _array[row, i];
                _array[row, i] = temp;
            }
        }
}

FillArray(array);
for (int i = 0; i < array.GetLength(0); i++) SortString(array, i);
PrintArray(array);

/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить 
строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой 
элементов: 1 строка*/
Console.WriteLine("\nПрограмма находит строку с наименьшей суммой элементов:");
int StringSum(int[,] _array, int row)
{
    int sum = 0;
    for (int j = 0; j < _array.GetLength(1); j++)
    {
        sum += _array[row, j];
    }
    return sum;
}


int[,] newArray = new int[8, 6];
FillArray(newArray);
int min = 0;
Console.WriteLine($"Сумма элементов {min}-й строки: {StringSum(newArray, min)}");
for (int i = 1; i < newArray.GetLength(0); i++)
{
    min = StringSum(newArray, i) < StringSum(newArray, min) ? i : min;
    Console.WriteLine($"Сумма элементов {i}-й строки: {StringSum(newArray, i)}");
}
Console.Write($"В массиве наименьшая сумма элементов в {min}-й строке\n");



/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/
Console.WriteLine("\nПрограмма перемножает матрицы и выводит результирующую матрицу:");
int[,] array1 = new int[2, 2];
int[,] array2 = new int[2, 2];
int[,] resultArray = new int[2, 2];
FillArray(array1, 1, 10);
FillArray(array2, 1, 10);
for (int i = 0; i < resultArray.GetLength(0); i++)
{
    for (int j = 0; j < resultArray.GetLength(1); j++)
    {
        resultArray[i, j] = array1[i, j] * array2[i, j];
    }
}
PrintArray(resultArray);


/*Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)*/
Console.WriteLine("\nПрограмма создает трехмерный массив из неповторяющихся двузначных чисел:");
int[,,] array3D = new int[2, 2, 2];

bool RepeatedEl(int[,,] _array, int value)
{
    bool res = false;
    foreach (var el in _array) res = res || el == value;
    return res;
}

for (int i = 0; i < array3D.GetLength(0); i++)
{
    for (int j = 0; j < array3D.GetLength(1); j++)
    {
        for (int k = 0; k < array3D.GetLength(2); k++)
        {
            int temp = new Random().Next(10, 100);
            while (RepeatedEl(array3D, temp))
            {
                temp = new Random().Next(10, 100);
                Console.WriteLine("Было повторение, исправлено");
            }
            array3D[i, j, k] = temp;
            Console.WriteLine($"{array3D[i, j, k]}({i},{j},{k})");
        }
    }
}

/*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07*/
Console.WriteLine("\nПрограмма спирально заполняет массив 4х4:");
int size = 9;
int[,] nArray = new int[size, size];

void FillArraySpiral(int[,] _array)
{
    int value = 1;
    int size = _array.GetLength(0);
    int filledRowUpper = 0;
    int filledRowLower = 0;
    int filledColLeft = 0;
    int filledColRight = 0;

    while (value <= size * size)
    {
        for (int j = filledColLeft; j < size - filledColRight; j++)
        {   //Заполняется верхняя строка
            int i = filledRowUpper;
            _array[i, j] = value;
            value++;
            Console.Write($"({i},{j})={_array[i, j]}, ");
        }
        filledRowUpper++;
        for (int i = filledRowUpper; i < size - filledRowLower; i++)
        {   //Заполняется правый столбец
            int j = size - filledColRight - 1;
            _array[i, j] = value;
            value++;
            Console.Write($"({i},{j})={_array[i, j]}, ");
        }
        filledColRight++;
        for (int j = size - filledColRight - 1; j >= filledColLeft; j--)
        {   //Заполняется нижняя строка
            int i = size - filledRowLower - 1;
            _array[i, j] = value;
            value++;
            Console.Write($"({i},{j})={_array[i, j]}, ");
        }
        filledRowLower++;
        for (int i = size - filledRowLower - 1; i >= filledRowUpper; i--)
        {   //Заполняется левый столбец
            int j = filledColLeft;
            _array[i, j] = value;
            value++;
            Console.Write($"({i},{j})={_array[i, j]}, ");
        }
        filledColLeft++;

    }
}

FillArraySpiral(nArray);
PrintArray(nArray);