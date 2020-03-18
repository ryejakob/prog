using System;
using static System.Console;
using static System.Math;
using static quad;
using static fun;

class main{
const double inf=double.PositiveInfinity;
static int Main(){

	Func<double,double> f = (x) => Log(x)/Sqrt(x);
	double a=0,b=1,result;
	result=quad.o8av(f,a,b);
	WriteLine($"-4={result}"); 

	Func<double,double> f2 = (x) => Exp(-Pow(x,2));
	double a2=-inf,b2=inf,result2;
	result2=quad.o8av(f2,a2,b2,acc:1e-6,eps:1e-6);
	WriteLine($"{Sqrt(PI)} ={result2}");
	
	for(double k=0; k<=5; k+=b){
	Func<double,double> f3 = (x) => Pow(Log(1/x),k);
	result=quad.o8av(f3,a,b);
	WriteLine($"{gamma(k+1)}={result}");} 



return 0;}
}
