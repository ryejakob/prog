using System;
using static System.Console;
using static System.Math;
using static quad;

class main{
const double inf=double.PositiveInfinity;
static int Main(){

	Func<double,double> f = (x) => Log(x)/Sqrt(x);
	double a=0,b=1,result;
	result=quad.o8av(f,a,b);
	WriteLine($"-4={result}"); 








return 0;}
}
