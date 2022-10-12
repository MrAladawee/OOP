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

Console.WriteLine();

dots O1 = new dots(1, 3, 0);
dots O2 = new dots(3, 1, 0);
dots P1 = new dots(5, 1, 0); // (1,2,0) - parr
dots P2 = new dots(3, -1, 0); // (2,1,0) - parr

double[] line1 = dots.Line2Dcoef(O1, O2);
double[] line2 = dots.Line2Dcoef(P1, P2);

//Console.WriteLine("{0}x {1}y {2} = 0, {3}x {4}y {5} = 0", line1[0], line1[1], line1[2], line2[0], line2[1], line2[2]);
//Console.WriteLine("Прямые пересекаются?: {0}", dots.Intersection2D(line1,line2));
//if (dots.Intersection2D(line1, line2) == true)
//{
//    Console.WriteLine("Пересечение по Ox = {0}", dots.IntersectionLine2D(line1, line2));
//    Console.WriteLine("Пересечение прямых отрезков лежит на самих отрезках? (пересекаются ли отрезки): {0}", dots.IntersectionBool2D(O1, O2, P1, P2));
//}

Console.WriteLine();

dots A1 = new dots(2,4,0);
dots B1 = new dots(4,6,0);
dots C1 = new dots(8,6,0);
dots D1 = new dots(8,2,0);

//dots A2 = new dots(2,-3,0);
//dots B2 = new dots(4,1,0);
//dots C2 = new dots(7,3,0); // (7,1,0) - without intersection
//dots D2 = new dots(7,-2,0);

dots A2 = new dots(3, 4, 0); // (3,3,0) - intersection.
dots B2 = new dots(4, 5, 0);
dots C2 = new dots(7, 5, 0);
dots D2 = new dots(7, 3, 0);

_4dots Qr1 = new _4dots(A1, B1, C1, D1);
_4dots Qr2 = new _4dots(A2, B2, C2, D2);

Console.WriteLine(String.Concat("The quadrilaterals ", (_4dots.Intersection2D(Qr1, Qr2)) ? "intersect" : "dont intersect"));
Console.WriteLine(String.Concat("The quadrilaterals are ", (_4dots.Including2D(Qr1, Qr2) == true) ? "nested" : "not nested"));
