// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
ClassWithArray.cArray A1 = new ClassWithArray.cArray(20);
ClassWithArray.cArray A2 = new ClassWithArray.cArray(20);
ClassWithArray.cArray A3 = new ClassWithArray.cArray();
A1.menu();
A2.menu();


Console.WriteLine(A1 != A2);
A3 = A1 - A2;
A3.menu();