using System;

class main{
	static int Main(string[] args) {
		
		var inp = new System.IO.StreamReader(args[0]);
		var outp = new System.IO.StreamWriter(args[1], append:true);
		string i;
		while((i = inp.ReadLine()) !=null){
			double x = double.Parse(i);
			outp.WriteLine($"{x} {Math.Cos(x)}");
		}
	
		outp.Close();

	return 0;}
}
