using dots_class;

dots dot = new dots();

dots z1 = new dots(1,2,3);
dots z2 = new dots(4,2,3);
dots z3 = new dots(6,2,1);
dots z4 = new dots();

// dot.print_dot(z1); // coordinate output

dot.dist_task1(z1, z2); // distance between 2 points
Console.WriteLine("");

dot.line_task2(z1, z2); // creation line throught 2 points
Console.WriteLine("");

dot.plot_task3(z1, z2, z3); // creation a flat throught 3 points
Console.WriteLine("");

dot.dist_task4(z1); // distance between (0,0,0) and point
Console.WriteLine("");

z4 = dot.sumvec_task5(z1, z2); // vector sum of 2 points
Console.Write("Vector sum of 2 points is "); dot.print_dot(z4);
Console.WriteLine("");

double scalar_dots = dot.scalar_task6(z1, z2); // scalar of 2 points
Console.WriteLine("Scalar of 2 points = {0}", scalar_dots);
Console.WriteLine("");

dot.vector_task6(z1, z2); // vector product of 2 points
