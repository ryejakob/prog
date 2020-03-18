using System;
using static System.Console;
using static System.Math;
using static quad;
using static fun;

class main{
const double inf=double.PositiveInfinity;
static int Main(){

	Func<double,double> f1 = (x) => Pow(x,3)/(Exp(x)-1);
	double a1=0,b1=inf,result1;
	result1=quad.o8av(f1,a1,b1);
	WriteLine($"{Pow(PI,4)/15}={result1}"); 

	double a=3;
	Func<double,double> f2 = (x) => Pow(x,3)*Exp(-a*Pow(x,2));
	result1=quad.o8av(f2,a1,b1);
	WriteLine($"{1/(2*Pow(a,2))}={result1}"); 
	
	Func<double,double> f3 = (x) => Sqrt(x)*Exp(-x);
	result1=quad.o8av(f3,a1,b1);
	WriteLine($"{0.5*Sqrt(PI)}={result1}"); 



return 0;}
}
