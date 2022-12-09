using TaskWithRazrMatrix;
using System.Collections;

DischargedMatrix<int> test = new DischargedMatrix<int>(4, 5);

test[2, 2] = 4;
test[0, 2] = 5;
test[0, 3] = 6;
test[3, 4] = 7;
test[1, 2] = 8;
test[0, 0] = 9;

test.show();
Console.WriteLine();
test.sq(0, 3).show();
