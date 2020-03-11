using System;
using static System.Console;
using static System.Math;
using static cmath;

class main{
	static int Main(){
		double x=2; 
		WriteLine($"sqrt(2)={Sqrt(x)}");
		complex I = new complex(0,1);
		complex ie = exp(I);
		WriteLine($"exp(i)={ie}");
		complex ie_1 =exp(PI*I);
		WriteLine($"exp(pi*i)={ie_1}");
		complex i_i= I.pow(I);
		WriteLine($"i^i={i_i}");
		complex isin= sin(PI*I);
		WriteLine($"sin(i*pi)={isin}");
		complex isinh= sinh(I);
		WriteLine($"sinh(i)={isinh}");
		complex icosh= cosh(I);
		WriteLine($"cosh(i)={icosh}");
		WriteLine($"sqrt(-1)={sqrt(-1)}");
		WriteLine($"sqrt(i)={sqrt(I)}");

	return 0; }
}
