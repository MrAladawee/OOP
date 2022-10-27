using ConsoleApp1;

//
// Initialization part
//
//
Console.WriteLine("Введите размерность матрицы: ");
int n = Convert.ToInt32(Console.ReadLine());
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

Matrix mass_1 = new Matrix(n, m);
Matrix mass_2 = new Matrix(n, m);

Console.WriteLine("Введите размерность матрицы для умножений: ");
int i = Convert.ToInt32(Console.ReadLine());
int j = Convert.ToInt32(Console.ReadLine());

Matrix mass_3 = new Matrix(i, j);

//
//
//
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

//Console.WriteLine("Вывод конкретного элемента по индексу:");
//int index_n = Convert.ToInt32(Console.ReadLine());
//int index_m = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine(String.Concat("Полученный элемент: ", Matrix.Recieve(mass_1, index_n, index_m)));


//
//
//

SqMatrix sqmass_1 = new SqMatrix(n);
SqMatrix sqmass_2 = new SqMatrix(n, true);

Console.WriteLine("Квадратная Матрица А': ");
sqmass_1.show();
Console.WriteLine();

Console.WriteLine("Квадратная Матрица B': ");
sqmass_2.show();
Console.WriteLine();

Console.WriteLine("Определитель |A'| = {0}", SqMatrix.Det(sqmass_1));
Console.WriteLine();

Console.WriteLine("Исправление линейной зависимости в матрице B:");
SqMatrix.Lin(sqmass_2).show();
Console.WriteLine();

InverseMatrix inmass_1 = new InverseMatrix(n);
InverseMatrix inmass_2 = new InverseMatrix(n);

inmass_1.matr[0,0] = 3;
inmass_1.matr[0,1] = 4;
inmass_1.matr[0,2] = 1;

inmass_1.matr[1,0] = 7;
inmass_1.matr[1,1] = 3;
inmass_1.matr[1,2] = 7;

inmass_1.matr[2,0] = 7;
inmass_1.matr[2,1] = 8;
inmass_1.matr[2,2] = 4;

Console.WriteLine("Квадратная Обратимая матрица A'': ");
inmass_1.show();
Console.WriteLine();

Console.WriteLine("Определитель |A''| = {0}", SqMatrix.Det(inmass_1));
Console.WriteLine();

Console.WriteLine("Обратная матрица к A'': ");
InverseMatrix inmass_1Inverse = InverseMatrix.Inverse(inmass_1);
inmass_1Inverse.show();
Console.WriteLine();

Console.WriteLine("Проверка корректности обратной матрицы к A'': ");
InverseMatrix.CheckInverse(inmass_1, inmass_1Inverse).show();
