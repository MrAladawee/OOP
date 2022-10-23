using ConsoleApp1;


//
// Initialization part
//
//
Console.WriteLine("Введите размерность матрицы: ");
int n = Convert.ToInt32(Console.ReadLine());
int m = Convert.ToInt32(Console.ReadLine());

Matrix mass_1 = new Matrix(n, m);
Matrix mass_2 = new Matrix(n, m);

Console.WriteLine("Введите размерность матрицы для умножений: ");
int i = Convert.ToInt32(Console.ReadLine());
int j = Convert.ToInt32(Console.ReadLine());

Matrix mass_3 = new Matrix(i, j);

Matrix mass1 = new Matrix(n, m);
Matrix mass2 = new Matrix(n, m);
Matrix mass3 = new Matrix(n, m);
Matrix mass4 = new Matrix(n, m);
Matrix mass5 = new Matrix(n, m);
Matrix mass6 = new Matrix(n, m);
Matrix mass7 = new Matrix(n, m);
Matrix mass8 = new Matrix(n, m);
Matrix mass9 = new Matrix(n, m);
Matrix mass10 = new Matrix(n, m);
Matrix mass11 = new Matrix(n, m);
Matrix mass12 = new Matrix(n, m);

Console.WriteLine(); Console.WriteLine();


//
// Main part
//
//
Console.WriteLine("Матрица А: ");
mass_1.show();
Console.WriteLine();
Console.WriteLine("Матрица В: ");
mass_2.show();
Console.WriteLine();
Console.WriteLine("Матрица C: ");
mass_3.show();
Console.WriteLine();

Console.WriteLine("Сложение матриц А и B: ");
mass1 = (mass_1 + mass_2);
mass1.show();
Console.WriteLine();

Console.WriteLine("Вычитание матриц А и B: ");
mass2 = (mass_1 - mass_2);
mass2.show();
Console.WriteLine();

Console.WriteLine("Умножение матрицы А на число 2: ");
mass3 = (mass_1 * 2);
mass3.show();
Console.WriteLine();

Console.WriteLine("Умножение матриц А и C: ");
mass4 = (mass_1 * mass_3);
mass4.show();
Console.WriteLine();

Console.WriteLine("Транспозиция матрицы C:");
mass5 = Matrix.Transp(mass_3);
mass5.show();
Console.WriteLine();

Console.WriteLine("Вывод конкретного элемента по индексу:");
int index_n = Convert.ToInt32(Console.ReadLine());
int index_m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(String.Concat("Полученный элемент: ", Matrix.Recieve(mass11, index_n, index_m)));
