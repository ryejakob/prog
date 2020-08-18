using static System.Console;
using System;


class stdin{
	static int Main(){
		System.IO.TextReader stdin = System.Console.In;
		
		string s;

		while( (s = stdin.ReadLine()) !=null) {
		double x = double.Parse(s);
		WriteLine($"{x} {Math.Sin(x)} {Math.Cos(x)}");
		}




	return 0;}
}
