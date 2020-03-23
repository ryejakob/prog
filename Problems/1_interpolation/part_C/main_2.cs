using System;
using static System.Console;
using static System.Math;
using static vector;
using static cspline;


class main{
	static int Main(string[] args) {
		// input to vector...
		var input = new System.IO.StreamReader("sin_data.txt");
		int input_lenght = 0;
		while(input.ReadLine() !=null) {
			input_lenght++; }
		input.Close();
		input = new System.IO.StreamReader("sin_data.txt");
		vector x1 = new vector(input_lenght);
		vector y1 = new vector(input_lenght);
		
		string line;
		for(int n=0; n<input_lenght; n++){
			line = input.ReadLine();
			string[] words = line.Split(' ');
			x1[n] = double.Parse(words[0]);
			y1[n] = double.Parse(words[1]);
		}
		/// end input to vector 
		cspline a=new cspline(x1,y1);		
		
		for(double n=0; n<=10; n+=0.05){
			WriteLine($"{n} {a.cderivative(n)}");
			}
		
		
		

			

	return 0;}
}
