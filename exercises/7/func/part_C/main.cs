using System;
using static System.Console;
using static System.Math;
using static quad;
using static fun;

class main{
const double inf=double.PositiveInfinity;
static int Main(){
	double a1=-inf,b1=inf,result1,result2,E_a;	
	for(double a=0.01; a<=3; a+=0.1){

	Func<double,double> f1 = (x) => Exp(-a*Pow(x,2));
	result1=quad.o8av(f1,a1,b1);
	
	Func<double,double> f2 = (x) => (-Pow(a,2)*Pow(x,2)/2 + a/2 + Pow(x,2)/2)*Exp(-a*Pow(x,2)); 
	result2=quad.o8av(f2,a1,b1);
	E_a=result2/result1;
	WriteLine($"{a} {E_a}");
}

return 0;}
}
