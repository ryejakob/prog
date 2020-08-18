using System;

class main{
	static int main(string[] args) {
		
		var in_put = new System.IO.StreamReader(args[0]);
		var out_p = new System.IO.StreamWriter(args[1], append:true);
		string i;
		while((i = in_put.ReadLine()) !=null){
			double x = double.Parse(i);
			outp.WriteLine($"{x} {Math.Cos(x)}");
		}
	

		out_P.Close();
	return 0;}
}
