using System;
using static System.Console;
using static System.Math;
using static quad;
using static fun;

class main{
const double inf=double.PositiveInfinity;
static int Main(){

	WriteLine("Part B:");
	WriteLine($"More tests");
	Func<double,double> f1 = (x) => Pow(x,3)/(Exp(x)-1);
	double a1=0,b1=inf,result1;
	result1=quad.o8av(f1,a1,b1);
	WriteLine($" Function: x³/(exp(x)-1) from 0 to infinity");
	WriteLine($"{Pow(PI,4)/15}={result1}"); 
WriteLine("");

	double a=3;
	Func<double,double> f2 = (x) => Pow(x,3)*Exp(-a*Pow(x,2));
	result1=quad.o8av(f2,a1,b1);
	WriteLine($" Function: x³*exp(-3*x²) from 0 to infinity");
	WriteLine($"{1/(2*Pow(a,2))}={result1}"); 
WriteLine("");
	
	Func<double,double> f3 = (x) => Sqrt(x)*Exp(-x);
	result1=quad.o8av(f3,a1,b1);
	WriteLine($" Function: sqrt(x)*exp(-x) from 0 to infinity");
	WriteLine($"{0.5*Sqrt(PI)}={result1}"); 



return 0;}
}
