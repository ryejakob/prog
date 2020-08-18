using System;

class cmdline{
	static int Main(string[] args){
		foreach(string s in args){
			double x = double.Parse(s);
		
		Console.WriteLine($"{x} {Math.Sin(x)} {Math.Cos(x)}");
		}

	return 0; }
}
