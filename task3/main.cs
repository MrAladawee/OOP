using dots_class;

dots A = new dots(0, 0, 0);
dots B = new dots(3, -1, 0);
dots C = new dots(3, 2, 0);
dots D = new dots(0, 2, 0);

_4dots Qr = new _4dots(A, B, C, D);

Console.WriteLine("Area: {0}", _4dots.Area(Qr));
Console.WriteLine("Perimeter: {0}", _4dots.Perimeter(Qr));
Console.WriteLine("Diagonales: {0}, {1}", _4dots.Diagonale(Qr)[0], _4dots.Diagonale(Qr)[1]);

Console.WriteLine();

Console.WriteLine(String.Concat("The quadrilateral is ", (_4dots.Сonvexity(Qr) == true) ? "convex" : "non-convex"));

Console.WriteLine();

Console.WriteLine(String.Concat("The quadrilateral is ", (_4dots.IdSquare(Qr) == true) ? "square" : "not square"));
Console.WriteLine(String.Concat("The quadrilateral is ", (_4dots.IdRectangle(Qr) == true) ? "rectangle" : "not rectangle"));
Console.WriteLine(String.Concat("The quadrilateral is ", (_4dots.IdParallelogram(Qr) == true) ? "parallelogram" : "not parallelogram"));
Console.WriteLine(String.Concat("The quadrilateral is ", (_4dots.IdRhombus(Qr) == true) ? "rhombus" : "not rhombus"));
Console.WriteLine(String.Concat("The quadrilateral is ", (_4dots.IdTrapeze(Qr) == true) ? "trapeze" : "not trapeze"));
