using dots_class;

dots A = new dots(2,10,0);
dots B = new dots(10,8,0);
dots C = new dots(8,0,0);
dots D = new dots(0,2,0);

_4dots Qr = new _4dots(A, B, C, D);

Console.WriteLine("Area: {0}", _4dots.Area(Qr));
Console.WriteLine("Perimeter: {0}", _4dots.Perimeter(Qr));
Console.WriteLine("Diagonales: {0}, {1}", _4dots.Diagonale(Qr)[0], _4dots.Diagonale(Qr)[1]);
Console.WriteLine(String.Concat("The quadrilateral is ", (_4dots.Сonvexity(Qr) == true) ? "convex" : "non-convex"));
